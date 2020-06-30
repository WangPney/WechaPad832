using org.apache.rocketmq.client.consumer;
using org.apache.rocketmq.client.consumer.listener;
using org.apache.rocketmq.client.producer;
using org.apache.rocketmq.common.consumer;
using org.apache.rocketmq.common.message;
using org.apache.rocketmq.common.protocol.heartbeat;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wechat.Util.Mq
{
    public class RocketMqHelper
    {
        private static readonly string namesrvAddr = null;
        private static IList<DefaultMQProducer> producers = new List<DefaultMQProducer>();
        private static IList<DefaultMQPushConsumer> consumers = new List<DefaultMQPushConsumer>();
        private static object producer_lock = new object();
        private static object consumer_lock = new object();

        static RocketMqHelper()
        {
            namesrvAddr = ConfigurationManager.AppSettings["RocketMqIp"];
            if (string.IsNullOrEmpty(namesrvAddr))
            {
                namesrvAddr = "47.106.232.106:9876";
            }
        }




        /// <summary>
        /// 创建生产者
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        public static DefaultMQProducer CreateDefaultMQProducer(string groupName, int queueCount = 4)
        {
            var producer = producers.Where(o => o.getProducerGroup() == groupName).FirstOrDefault();
            if (producer == null) //双if +lock
            {
                lock (producer_lock)
                {
                    producer = producers.Where(o => o.getProducerGroup() == groupName).FirstOrDefault();
                    if (producer == null)
                    {
                        producer = new DefaultMQProducer(groupName);
                        producer.setNamesrvAddr(namesrvAddr);
                        producer.setRetryTimesWhenSendFailed(3);
                        producer.setDefaultTopicQueueNums(queueCount);
                        producer.start();
                        producers.Add(producer);

                    }
                }
            }
            return producer;
        }



        /// <summary>
        /// 创建消费者
        /// </summary>
        /// <param name="group"></param> 
        /// <returns></returns>
        public static DefaultMQPushConsumer CreateDefaultMQPushConsumer<T>(string groupName) where T : MessageListenerConcurrently
        {
            var consumer = consumers.Where(o => o.getConsumerGroup() == groupName).FirstOrDefault();
            if (consumer == null) //双if +lock
            {
                lock (consumer_lock)
                {
                    consumer = consumers.Where(o => o.getConsumerGroup() == groupName).FirstOrDefault();
                    if (consumer == null)
                    {
                        consumer = new DefaultMQPushConsumer(groupName);
                        consumer.setNamesrvAddr(namesrvAddr);
                        consumer.setMessageModel(MessageModel.CLUSTERING);
                        consumer.setConsumeFromWhere(ConsumeFromWhere.CONSUME_FROM_FIRST_OFFSET);
                        consumer.registerMessageListener(Activator.CreateInstance<T>());
                        consumer.start();
                        consumers.Add(consumer);
                    }
                }
            }
            return consumer;
        }


        /// <summary>
        /// 创建消费者
        /// </summary>
        /// <param name="group"></param> 
        /// <returns></returns>
        public static DefaultMQPushConsumer CreateDefaultMQPushConsumer(MessageListenerConcurrently messageListenerConcurrentlytype, string groupName) 
        {
            var consumer = consumers.Where(o => o.getConsumerGroup() == groupName).FirstOrDefault();
            if (consumer == null) //双if +lock
            {
                lock (consumer_lock)
                {
                    consumer = consumers.Where(o => o.getConsumerGroup() == groupName).FirstOrDefault();
                    if (consumer == null)
                    {
                        consumer = new DefaultMQPushConsumer(groupName);
                        consumer.setNamesrvAddr(namesrvAddr);
                        consumer.setMessageModel(MessageModel.CLUSTERING);
                        consumer.setConsumeFromWhere(ConsumeFromWhere.CONSUME_FROM_FIRST_OFFSET);
                        consumer.registerMessageListener(messageListenerConcurrentlytype);
                        consumer.start();
                        consumers.Add(consumer);
                    }
                }
            }
            return consumer;
        }


    }







}

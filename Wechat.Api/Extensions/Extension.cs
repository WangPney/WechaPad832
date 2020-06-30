using Newtonsoft.Json;
using System;
using System.IO;

namespace Wechat.Api.Extensions
{
    public static class Extension
    {
        public static bool TryDeserializeJsonStr<T>(this string jsonStr, out T data)
        {
            data = default(T);
            if (string.IsNullOrWhiteSpace(jsonStr))
            {
                return false;
            }
            try
            {
                data = JsonConvert.DeserializeObject<T>(jsonStr);
                return data != null;
            }
            catch
            {
                return false;
            }
        }

        public static bool TryDeserializeJsonStr(this string jsonStr, Type outType, out object data)
        {
            data = null;
            if (string.IsNullOrWhiteSpace(jsonStr))
            {
                return false;
            }
            try
            {
                data = JsonConvert.DeserializeObject(jsonStr, outType);
                return data != null;
            }
            catch
            {
                return false;
            }
        }

        public static string ToJsonString(this object data, Formatting formatting = Formatting.None)
        {
            if (data == null)
            {
                return "{}";
            }
            return JsonConvert.SerializeObject(data, formatting);
        }
        public static MMPro.MM.VoiceFormat GetVoiceType(this string fileName)
        {
            MMPro.MM.VoiceFormat voiceFormat = MMPro.MM.VoiceFormat.MM_VOICE_FORMAT_UNKNOWN;
            string extension = Path.GetExtension(fileName).ToLower();
            switch (extension)
            {
                case ".wav": voiceFormat = MMPro.MM.VoiceFormat.MM_VOICE_FORMAT_WAVE; break;
                case ".mp3": voiceFormat = MMPro.MM.VoiceFormat.MM_VOICE_FORMAT_MP3; break;
                case ".silk": voiceFormat = MMPro.MM.VoiceFormat.MM_VOICE_FORMAT_SILK; break;
                case ".speex ": voiceFormat = MMPro.MM.VoiceFormat.MM_VOICE_FORMAT_WAVE; break;
                case ".amr": voiceFormat = MMPro.MM.VoiceFormat.MM_VOICE_FORMAT_AMR; break;
            }
            return voiceFormat;
        }
    }
}
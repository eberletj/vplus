﻿using System;
using System.Runtime.InteropServices;
using System.Text;

namespace FMOD
{
    public class Sound
    {
        private IntPtr _soundraw;

        public RESULT AddSyncPoint(int offset, TIMEUNIT offsettype, string name, ref IntPtr point)
        {
            return FMOD_Sound_AddSyncPoint(_soundraw, offset, offsettype, name, ref point);
        }

        public RESULT DeleteSyncPoint(IntPtr point)
        {
            return FMOD_Sound_DeleteSyncPoint(_soundraw, point);
        }

        [DllImport("fmodex.dll")]
        private static extern RESULT FMOD_Sound_AddSyncPoint(IntPtr sound, int offset, TIMEUNIT offsettype, string name, ref IntPtr point);
        [DllImport("fmodex.dll")]
        private static extern RESULT FMOD_Sound_DeleteSyncPoint(IntPtr sound, IntPtr point);
        [DllImport("fmodex.dll")]
        private static extern RESULT FMOD_Sound_Get3DConeSettings(IntPtr sound, ref float insideconeangle, ref float outsideconeangle, ref float outsidevolume);
        [DllImport("fmodex.dll")]
        private static extern RESULT FMOD_Sound_Get3DCustomRolloff(IntPtr sound, ref IntPtr points, ref int numpoints);
        [DllImport("fmodex.dll")]
        private static extern RESULT FMOD_Sound_Get3DMinMaxDistance(IntPtr sound, ref float min, ref float max);
        [DllImport("fmodex.dll")]
        private static extern RESULT FMOD_Sound_GetDefaults(IntPtr sound, ref float frequency, ref float volume, ref float pan, ref int priority);
        [DllImport("fmodex.dll")]
        private static extern RESULT FMOD_Sound_GetFormat(IntPtr sound, ref SOUND_TYPE type, ref SOUND_FORMAT format, ref int channels, ref int bits);
        [DllImport("fmodex.dll")]
        private static extern RESULT FMOD_Sound_GetLength(IntPtr sound, ref uint length, TIMEUNIT lengthtype);
        [DllImport("fmodex.dll")]
        private static extern RESULT FMOD_Sound_GetLoopCount(IntPtr sound, ref int loopcount);
        [DllImport("fmodex.dll")]
        private static extern RESULT FMOD_Sound_GetLoopPoints(IntPtr sound, ref uint loopstart, TIMEUNIT loopstarttype, ref uint loopend, TIMEUNIT loopendtype);
        [DllImport("fmodex.dll")]
        private static extern RESULT FMOD_Sound_GetMode(IntPtr sound, ref MODE mode);
        [DllImport("fmodex.dll")]
        private static extern RESULT FMOD_Sound_GetName(IntPtr sound, StringBuilder name, int namelen);
        [DllImport("fmodex.dll")]
        private static extern RESULT FMOD_Sound_GetNumSubSounds(IntPtr sound, ref int numsubsounds);
        [DllImport("fmodex.dll")]
        private static extern RESULT FMOD_Sound_GetNumSyncPoints(IntPtr sound, ref int numsyncpoints);
        [DllImport("fmodex.dll")]
        private static extern RESULT FMOD_Sound_GetNumTags(IntPtr sound, ref int numtags, ref int numtagsupdated);
        [DllImport("fmodex.dll")]
        private static extern RESULT FMOD_Sound_GetOpenState(IntPtr sound, ref OPENSTATE openstate, ref uint percentbuffered, ref bool starving);
        [DllImport("fmodex.dll")]
        private static extern RESULT FMOD_Sound_GetSubSound(IntPtr sound, int index, ref IntPtr subsound);
        [DllImport("fmodex.dll")]
        private static extern RESULT FMOD_Sound_GetSyncPoint(IntPtr sound, int index, ref IntPtr point);
        [DllImport("fmodex.dll")]
        private static extern RESULT FMOD_Sound_GetSyncPointInfo(IntPtr sound, IntPtr point, StringBuilder name, int namelen, ref uint offset, TIMEUNIT offsettype);
        [DllImport("fmodex.dll")]
        private static extern RESULT FMOD_Sound_GetSystemObject(IntPtr sound, ref IntPtr system);
        [DllImport("fmodex.dll")]
        private static extern RESULT FMOD_Sound_GetTag(IntPtr sound, string name, int index, ref TAG tag);
        [DllImport("fmodex.dll")]
        private static extern RESULT FMOD_Sound_GetUserData(IntPtr sound, ref IntPtr userdata);
        [DllImport("fmodex.dll")]
        private static extern RESULT FMOD_Sound_GetVariations(IntPtr sound, ref float frequencyvar, ref float volumevar, ref float panvar);
        [DllImport("fmodex.dll")]
        private static extern RESULT FMOD_Sound_Lock(IntPtr sound, uint offset, uint length, ref IntPtr ptr1, ref IntPtr ptr2, ref uint len1, ref uint len2);
        [DllImport("fmodex.dll")]
        private static extern RESULT FMOD_Sound_ReadData(IntPtr sound, IntPtr buffer, uint lenbytes, ref uint read);
        [DllImport("fmodex.dll")]
        private static extern RESULT FMOD_Sound_Release(IntPtr sound);
        [DllImport("fmodex.dll")]
        private static extern RESULT FMOD_Sound_SeekData(IntPtr sound, uint pcm);
        [DllImport("fmodex.dll")]
        private static extern RESULT FMOD_Sound_Set3DConeSettings(IntPtr sound, float insideconeangle, float outsideconeangle, float outsidevolume);
        [DllImport("fmodex.dll")]
        private static extern RESULT FMOD_Sound_Set3DCustomRolloff(IntPtr sound, ref VECTOR points, int numpoints);
        [DllImport("fmodex.dll")]
        private static extern RESULT FMOD_Sound_Set3DMinMaxDistance(IntPtr sound, float min, float max);
        [DllImport("fmodex.dll")]
        private static extern RESULT FMOD_Sound_SetDefaults(IntPtr sound, float frequency, float volume, float pan, int priority);
        [DllImport("fmodex.dll")]
        private static extern RESULT FMOD_Sound_SetLoopCount(IntPtr sound, int loopcount);
        [DllImport("fmodex.dll")]
        private static extern RESULT FMOD_Sound_SetLoopPoints(IntPtr sound, uint loopstart, TIMEUNIT loopstarttype, uint loopend, TIMEUNIT loopendtype);
        [DllImport("fmodex.dll")]
        private static extern RESULT FMOD_Sound_SetMode(IntPtr sound, MODE mode);
        [DllImport("fmodex.dll")]
        private static extern RESULT FMOD_Sound_SetSubSound(IntPtr sound, int index, IntPtr subsound);
        [DllImport("fmodex.dll")]
        private static extern RESULT FMOD_Sound_SetSubSoundSentence(IntPtr sound, int[] subsoundlist, int numsubsounds);
        [DllImport("fmodex.dll")]
        private static extern RESULT FMOD_Sound_SetUserData(IntPtr sound, IntPtr userdata);
        [DllImport("fmodex.dll")]
        private static extern RESULT FMOD_Sound_SetVariations(IntPtr sound, float frequencyvar, float volumevar, float panvar);
        [DllImport("fmodex.dll")]
        private static extern RESULT FMOD_Sound_Unlock(IntPtr sound, IntPtr ptr1, IntPtr ptr2, uint len1, uint len2);
        public RESULT get3DConeSettings(ref float insideconeangle, ref float outsideconeangle, ref float outsidevolume)
        {
            return FMOD_Sound_Get3DConeSettings(_soundraw, ref insideconeangle, ref outsideconeangle, ref outsidevolume);
        }

        public RESULT get3DCustomRolloff(ref IntPtr points, ref int numpoints)
        {
            return FMOD_Sound_Get3DCustomRolloff(_soundraw, ref points, ref numpoints);
        }

        public RESULT get3DMinMaxDistance(ref float min, ref float max)
        {
            return FMOD_Sound_Get3DMinMaxDistance(_soundraw, ref min, ref max);
        }

        public RESULT getDefaults(ref float frequency, ref float volume, ref float pan, ref int priority)
        {
            return FMOD_Sound_GetDefaults(_soundraw, ref frequency, ref volume, ref pan, ref priority);
        }

        public RESULT getFormat(ref SOUND_TYPE type, ref SOUND_FORMAT format, ref int channels, ref int bits)
        {
            return FMOD_Sound_GetFormat(_soundraw, ref type, ref format, ref channels, ref bits);
        }

        public RESULT getLength(ref uint length, TIMEUNIT lengthtype)
        {
            return FMOD_Sound_GetLength(_soundraw, ref length, lengthtype);
        }

        public RESULT getLoopCount(ref int loopcount)
        {
            return FMOD_Sound_GetLoopCount(_soundraw, ref loopcount);
        }

        public RESULT getLoopPoints(ref uint loopstart, TIMEUNIT loopstarttype, ref uint loopend, TIMEUNIT loopendtype)
        {
            return FMOD_Sound_GetLoopPoints(_soundraw, ref loopstart, loopstarttype, ref loopend, loopendtype);
        }

        public RESULT getMode(ref MODE mode)
        {
            return FMOD_Sound_GetMode(_soundraw, ref mode);
        }

        public RESULT getName(StringBuilder name, int namelen)
        {
            return FMOD_Sound_GetName(_soundraw, name, namelen);
        }

        public RESULT getNumSubSounds(ref int numsubsounds)
        {
            return FMOD_Sound_GetNumSubSounds(_soundraw, ref numsubsounds);
        }

        public RESULT getNumSyncPoints(ref int numsyncpoints)
        {
            return FMOD_Sound_GetNumSyncPoints(_soundraw, ref numsyncpoints);
        }

        public RESULT getNumTags(ref int numtags, ref int numtagsupdated)
        {
            return FMOD_Sound_GetNumTags(_soundraw, ref numtags, ref numtagsupdated);
        }

        public RESULT getOpenState(ref OPENSTATE openstate, ref uint percentbuffered, ref bool starving)
        {
            return FMOD_Sound_GetOpenState(_soundraw, ref openstate, ref percentbuffered, ref starving);
        }

        public IntPtr getRaw()
        {
            return _soundraw;
        }

        public RESULT getSubSound(int index, ref Sound subsound)
        {
            RESULT oK = RESULT.OK;
            IntPtr ptr = new IntPtr();
            Sound sound = null;
            try
            {
                oK = FMOD_Sound_GetSubSound(_soundraw, index, ref ptr);
            }
            catch
            {
                oK = RESULT.ERR_INVALID_PARAM;
            }
            if (oK == RESULT.OK)
            {
                if (subsound == null)
                {
                    sound = new Sound();
                    sound.setRaw(ptr);
                    subsound = sound;
                }
                else
                {
                    subsound.setRaw(ptr);
                }
            }
            return oK;
        }

        public RESULT getSyncPoint(int index, ref IntPtr point)
        {
            return FMOD_Sound_GetSyncPoint(_soundraw, index, ref point);
        }

        public RESULT getSyncPointInfo(IntPtr point, StringBuilder name, int namelen, ref uint offset, TIMEUNIT offsettype)
        {
            return FMOD_Sound_GetSyncPointInfo(_soundraw, point, name, namelen, ref offset, offsettype);
        }

        public RESULT getSystemObject(ref System system)
        {
            RESULT oK = RESULT.OK;
            IntPtr ptr = new IntPtr();
            System system2 = null;
            try
            {
                oK = FMOD_Sound_GetSystemObject(_soundraw, ref ptr);
            }
            catch
            {
                oK = RESULT.ERR_INVALID_PARAM;
            }
            if (oK == RESULT.OK)
            {
                if (system == null)
                {
                    system2 = new System();
                    system2.setRaw(ptr);
                    system = system2;
                }
                else
                {
                    system.setRaw(ptr);
                }
            }
            return oK;
        }

        public RESULT getTag(string name, int index, ref TAG tag)
        {
            return FMOD_Sound_GetTag(_soundraw, name, index, ref tag);
        }

        public RESULT getUserData(ref IntPtr userdata)
        {
            return FMOD_Sound_GetUserData(_soundraw, ref userdata);
        }

        public RESULT getVariations(ref float frequencyvar, ref float volumevar, ref float panvar)
        {
            return FMOD_Sound_GetVariations(_soundraw, ref frequencyvar, ref volumevar, ref panvar);
        }

        public RESULT @lock(uint offset, uint length, ref IntPtr ptr1, ref IntPtr ptr2, ref uint len1, ref uint len2)
        {
            return FMOD_Sound_Lock(_soundraw, offset, length, ref ptr1, ref ptr2, ref len1, ref len2);
        }

        public RESULT readData(IntPtr buffer, uint lenbytes, ref uint read)
        {
            return FMOD_Sound_ReadData(_soundraw, buffer, lenbytes, ref read);
        }

        public RESULT release()
        {
            return FMOD_Sound_Release(_soundraw);
        }

        public RESULT seekData(uint pcm)
        {
            return FMOD_Sound_SeekData(_soundraw, pcm);
        }

        public RESULT set3DConeSettings(float insideconeangle, float outsideconeangle, float outsidevolume)
        {
            return FMOD_Sound_Set3DConeSettings(_soundraw, insideconeangle, outsideconeangle, outsidevolume);
        }

        public RESULT set3DCustomRolloff(ref VECTOR points, int numpoints)
        {
            return FMOD_Sound_Set3DCustomRolloff(_soundraw, ref points, numpoints);
        }

        public RESULT set3DMinMaxDistance(float min, float max)
        {
            return FMOD_Sound_Set3DMinMaxDistance(_soundraw, min, max);
        }

        public RESULT setDefaults(float frequency, float volume, float pan, int priority)
        {
            return FMOD_Sound_SetDefaults(_soundraw, frequency, volume, pan, priority);
        }

        public RESULT setLoopCount(int loopcount)
        {
            return FMOD_Sound_SetLoopCount(_soundraw, loopcount);
        }

        public RESULT setLoopPoints(uint loopstart, TIMEUNIT loopstarttype, uint loopend, TIMEUNIT loopendtype)
        {
            return FMOD_Sound_SetLoopPoints(_soundraw, loopstart, loopstarttype, loopend, loopendtype);
        }

        public RESULT setMode(MODE mode)
        {
            return FMOD_Sound_SetMode(_soundraw, mode);
        }

        public void setRaw(IntPtr sound)
        {
            _soundraw = new IntPtr();
            _soundraw = sound;
        }

        public RESULT setSubSound(int index, Sound subsound)
        {
            IntPtr ptr = subsound.getRaw();
            return FMOD_Sound_SetSubSound(_soundraw, index, ptr);
        }

        public RESULT setSubSoundSentence(int[] subsoundlist, int numsubsounds)
        {
            return FMOD_Sound_SetSubSoundSentence(_soundraw, subsoundlist, numsubsounds);
        }

        public RESULT setUserData(IntPtr userdata)
        {
            return FMOD_Sound_SetUserData(_soundraw, userdata);
        }

        public RESULT setVariations(float frequencyvar, float volumevar, float panvar)
        {
            return FMOD_Sound_SetVariations(_soundraw, frequencyvar, volumevar, panvar);
        }

        public RESULT unlock(IntPtr ptr1, IntPtr ptr2, uint len1, uint len2)
        {
            return FMOD_Sound_Unlock(_soundraw, ptr1, ptr2, len1, len2);
        }
    }
}


﻿namespace Tools.Sound
{
    using UnityEngine;
    using Tools.Extensions;

    public static class ASourceCreator
    {
        public static AudioSource Create2DSource(AudioClip ac, string name, bool loop = false, bool playOnAwake = false)
        {
            Transform cam = Camera.main.transform;

            var source = cam
                .gameObject
                .CreateDefaultSubObject<AudioSource>("SOURCE-> " + name);

            source.clip = ac;
            source.loop = loop;
            source.spatialBlend = 0;
            source.playOnAwake = playOnAwake;
            if (playOnAwake) source.Play();

            return source;
        }
        public static AudioSource Create3DSource(AudioClip ac,string name, Transform parent, bool loop = false, bool playOnAwake = false)
        {
            var source = parent
                .gameObject
                .CreateDefaultSubObject<AudioSource>("SOURCE-> " + name);

            source.clip = ac;
            source.loop = loop;
            source.spatialBlend = 1;
            source.playOnAwake = playOnAwake;
            if (playOnAwake) source.Play();

            return source;
        }

        public static void PlayIfNotPlaying(this AudioSource ac)
        {
            if (!ac.isPlaying) ac.Play();
        }
    }
}
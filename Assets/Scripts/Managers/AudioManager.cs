using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeDefense
{
    /// <summary>
    /// Global Audio Manager
    /// </summary>
    public class AudioManager : Singleton<AudioManager>
    {
        public const int CIdBuy = 0;
        public const int CIdBuild = 1;
        public const int CIdClick = 2;
        public const int CIdDead = 3;
        public const int CIdExplosion = 4;
        public const int CIdGameOver = 5;
        public const int CIdLostLife = 6;
        public const int CIdWin = 7;
        public const int CIdIce = 8;

        public const int CIdBgMenu = 0;
        public const int CIdBgGame = 1;

        [SerializeField] private AudioSource sfxSource;
        [SerializeField] private AudioSource backgroundSource;

        [SerializeField] private AudioClip[] sfxClips;
        [SerializeField] private AudioClip[] bgClips;

        /// <summary>
        /// Play a simple fx
        /// </summary>
        /// <param name="id">Clip id</param>
        public void PlaySfx(int id)
        {
            if (id >= sfxClips.Length)
                return;
            sfxSource.PlayOneShot(sfxClips[id]);
        }

        /// <summary>
        /// Play background music
        /// </summary>
        /// <param name="id">Clip id</param>
        public void PlayBackground(int id)
        {
            if (id >= sfxClips.Length)
                return;
            backgroundSource.clip = bgClips[id];
            backgroundSource.Play();
        }
    }
}
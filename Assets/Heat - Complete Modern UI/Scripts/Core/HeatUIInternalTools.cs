using UnityEngine;

namespace Michsky.UI.Heat
{
    public class HeatUIInternalTools : MonoBehaviour
    {

        public static float GetAnimatorClipLength(Animator _animator, string _clipName)
        {
            if (_animator == null || _animator.runtimeAnimatorController == null)
            {
                Debug.LogWarning($"GetAnimatorClipLength called with null animator or controller. Clip: {_clipName}");
                return 0f;
            }

            RuntimeAnimatorController _rac = _animator.runtimeAnimatorController;

            foreach (var clip in _rac.animationClips)
            {
                if (clip.name == _clipName)
                    return clip.length;
            }

            return 0f; // Return 0 if clip not found
        }


        /*public static float GetAnimatorClipLength(Animator _animator, string _clipName)
        {
            float _lengthValue = -1;
            RuntimeAnimatorController _rac = _animator.runtimeAnimatorController;

            for (int i = 0; i < _rac.animationClips.Length; i++)
            {
                if (_rac.animationClips[i].name == _clipName)
                {
                    _lengthValue = _rac.animationClips[i].length;
                    break;
                }
            }

            return _lengthValue;
        }*/
    }
}
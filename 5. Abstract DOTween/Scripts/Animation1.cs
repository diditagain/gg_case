using DG.Tweening;
using UnityEngine;

namespace Challenges._6._Abstract_DOTween.Scripts
{

    public class Animation1 : DoTweenAnimation
    {
        //Add parameters here
        [SerializeField]
        public float _jumpHeight;
        public float _jumpPower;
        public float _fallStrength;
        public float _jumpDuration;
        public float _fallDuration;
        public float _scaleMultiplier;
        public float _shadeScale;
        public float _shadeEndDuration;

        /// <summary>
        /// Fill out this function
        /// </summary>
        /// <returns></returns>
        public override Tween StartPreview()
        {
            var sequence = DOTween.Sequence();
            sequence.Append(CenterObject.DOMoveY(CenterObject.position.y + _jumpHeight, _jumpDuration))
                .Join(CenterObject.DOScale(_scaleMultiplier, _jumpDuration))
                .Join(CenterObjectShade.DOMoveY(CenterObjectShade.position.y + _jumpHeight, _jumpDuration))
                .Append(CenterObject.DOMoveY(0, _fallDuration))
                .Join(CenterObject.DOScale(0, _fallDuration))
                .Join(CenterObjectShade.DOMoveY(0, _fallDuration))
                .Join(CenterObjectShade.DOScale(0, _fallDuration))
                .Append(CenterObjectShade.DOScale(_shadeScale, _shadeEndDuration))
                .Join(ShadeMaterial.DOFade(0, _shadeEndDuration));


            return sequence;
        }
    }
}

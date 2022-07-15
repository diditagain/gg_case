using DG.Tweening;
using UnityEngine;

namespace Challenges._6._Abstract_DOTween.Scripts
{

    public class Animation3 : DoTweenAnimation
    {
        //Add parameters here
        public float _scaleMultiplier;
        public float _growthDuration;
        public float _shrinkDuration;
        public float _shadeEndScale;
        public float _shadeEndDuration;

        /// <summary>
        /// Fill out this function
        /// </summary>
        /// <returns></returns>
        public override Tween StartPreview()
        {
            var sequence = DOTween.Sequence();
            sequence.Append(CenterObject.DOScale(CenterObject.localScale * _scaleMultiplier, _growthDuration))
                .Join(CenterObjectShade.DOScale(CenterObjectShade.localScale * _scaleMultiplier, _growthDuration))
                .Append(CenterObject.DOScale(CenterObject.localScale, _shrinkDuration / 2))
                .Join(CenterObjectShade.DOScale(CenterObjectShade.localScale, _shrinkDuration / 2))
                .Append(CenterObject.DOScale(0, _shrinkDuration / 2))
                .Join(CenterObjectShade.DOScale(_shadeEndScale, _shadeEndDuration))
                .Append(ShadeMaterial.DOFade(0, _shadeEndDuration));
            return sequence;
        }
    }
}

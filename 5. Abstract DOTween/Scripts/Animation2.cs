using DG.Tweening;
using UnityEngine;

namespace Challenges._6._Abstract_DOTween.Scripts
{

    public class Animation2 : DoTweenAnimation
    {
        //Add parameters here
        public float _scaleMultiplier;
        public float _growDuration;
        public float _shrinkDuration;
        public float _shadeEndScaleMultiplier;
        public float _shadeEndDuration;

        /// <summary>
        /// Fill out this function
        /// </summary>
        /// <returns></returns>
        public override Tween StartPreview()
        {
            
            var sequence = DOTween.Sequence();
            sequence.Append(CenterObject.DOScale(CenterObject.localScale * _scaleMultiplier, _growDuration))
                .Join(CenterObjectShade.DOScale(CenterObjectShade.localScale * _scaleMultiplier, _growDuration))
                .Append(CenterObject.DOScale(CenterObject.localScale, _shrinkDuration))
                .Join(CenterObjectShade.DOScale(CenterObjectShade.localScale, _shrinkDuration))
                .Append(CenterObjectShade.DOScale(CenterObjectShade.localScale * _shadeEndScaleMultiplier, _shadeEndDuration))
                .Join(ShadeMaterial.DOFade(0, _shadeEndDuration));
            return sequence;
        }
    }
}

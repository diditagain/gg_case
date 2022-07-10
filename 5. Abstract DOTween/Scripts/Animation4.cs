using DG.Tweening;
using UnityEngine;

namespace Challenges._6._Abstract_DOTween.Scripts
{

    public class Animation4 : DoTweenAnimation
    {
        //Add parameters here
        public float _fallDistance;
        public float _fallDuration;
        public float _jumpDistance;
        public float _jumpDuration;

        /// <summary>
        /// Fill out this function
        /// </summary>
        /// <returns></returns>
        public override Tween StartPreview()
        {
            var sequence = DOTween.Sequence();
            sequence.Append(CenterObject.DOMoveY(CenterObject.localPosition.y - _fallDistance, _fallDuration))
                .Join(CenterObjectShade.DOMoveY(CenterObjectShade.localPosition.y - _fallDistance, _fallDuration))
                .Append(CenterObject.DOMoveY(CenterObject.localPosition.y, _jumpDuration/2))
                .Join(CenterObjectShade.DOMoveY(CenterObjectShade.localPosition.y, _jumpDuration/2))
                .Append(CenterObject.DOMoveY(CenterObject.localPosition.y + _jumpDistance, _jumpDuration/2))
                .Join(CenterObjectShade.DOMoveY(CenterObjectShade.localPosition.y + _jumpDistance, _jumpDuration/2))
                .Join(CenterObject.DOScale(0, _jumpDuration))
                .Join(CenterObjectShade.DOScale(0, _jumpDuration));

            return sequence;
        }
    }
}

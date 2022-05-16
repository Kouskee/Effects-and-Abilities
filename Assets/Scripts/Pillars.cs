using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

public class Pillars : MonoBehaviour
{
   private VisualEffect _visualEffect;
   
   private float _scaleY;
   
   public void Install(float scaleY)
   {
      _scaleY = scaleY * 0.5f;
      transform.position = new Vector3( transform.position.x, 0,  transform.position.z);
      _visualEffect = GetComponentInChildren<VisualEffect>();
      _visualEffect.SetFloat("ScaleY", _scaleY);
      StartCoroutine(CheckNullParticle());
   }

   IEnumerator CheckNullParticle()
   {
      while (true)
      {
         yield return new WaitForSeconds(.25f);
         if(_visualEffect.aliveParticleCount <= 0)
            PoolObject.OnAbilityDestroy.Invoke(gameObject);
      }
   }
}

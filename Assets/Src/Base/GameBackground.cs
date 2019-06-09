using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBackground : MonoBehaviour
{
   private SpriteRenderer sprite;
   void Start()
   {
      // Init
      sprite = gameObject.GetComponent<SpriteRenderer>();

      // Thay đổi kích thước
		this.AutoReScale();
   }

   private void AutoReScale() {
      int width = GameSizeManager.currentResolution.width;
      int height = GameSizeManager.currentResolution.height;
      float factor = width / (sprite.bounds.size.x * GameConfig.SCREEN_SIZE_FACTOR);
      float factor2 = height / (sprite.bounds.size.y * GameConfig.SCREEN_SIZE_FACTOR);
      if (factor2 > factor)
         factor = factor2;
      this.ScaleBy(factor);
      // Debug.Log(factor);
   }

   public void ScaleBy(float factor) {
      Vector3 scale = gameObject.transform.localScale;
      scale.x = scale.x * factor;
      scale.y = scale.y * factor;
      gameObject.transform.localScale = scale;
   }
}
using UnityEngine;
using System.Collections;

[System.Serializable]
public class Bullet{
	[SerializeField] private string bulletName;
	[SerializeField] private Sprite bulletSprite;
	[SerializeField] private float bulletSpeed;

	public Bullet(){
	}

	public string BulletName{
		get{return bulletName;}
		set{bulletName = value;}
	}

	public Sprite BulletSprite{
		get{return bulletSprite;}
		set{bulletSprite = value;}
	}

	public float BulletSpeed{
		get{return bulletSpeed;}
		set{bulletSpeed = value;}
	}
}
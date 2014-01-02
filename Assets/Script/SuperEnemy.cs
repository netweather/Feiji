using UnityEngine;
using System.Collections;

[AddComponentMenu("MyGame/SuperEnemy")]
public class SuperEnemy : Enemy {

	protected  override void UpdateMove()
	{
		//前进
		m_transform.Translate( new Vector3(0,-m_speed * Time.deltaTime, 0 ));
	}
}

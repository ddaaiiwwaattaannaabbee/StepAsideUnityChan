using UnityEngine;
using System.Collections;

public class ItemGenerator : MonoBehaviour {
        //carPrefabを入れる
        public GameObject carPrefab;
        //coinPrefabを入れる
        public GameObject coinPrefab;
        //cornPrefabを入れる
        public GameObject conePrefab;
        //スタート地点
        private int startPos = -160;
        //ゴール地点
        private int goalPos = 120;
		//アイテム生成開始地点
		private int generatePos = 0;
		//アイテム生成間隔
		private int generateInterval = 15;
		//アイテム生成先の距離
		private int targetDistance = 45;
        //アイテムを出すx方向の範囲
        private float posRange = 3.4f;

        // Use this for initialization
        void Start () {
			this.generatePos = this.startPos;
        }

        // Update is called once per frame
        void Update () {
			
			//ユニティちゃんの座標を取得
			float unitychanPos = GameObject.Find("unitychan").transform.position.z;

			if((this.generatePos < unitychanPos ) && ( unitychanPos < this.generatePos + this.generateInterval)){
				
				int targetPos = this.generatePos + this.targetDistance;

				if(targetPos < this.goalPos){
					
					//どのアイテムを出すのかをランダムに設定
					int num = Random.Range (0, 10);
					if (num <= 1) {
							//コーンをx軸方向に一直線に生成
							for (float j = -1; j <= 1; j += 0.4f) {
									GameObject cone = Instantiate (conePrefab) as GameObject;
									cone.transform.position = new Vector3 (4 * j, cone.transform.position.y, targetPos);
							}
					} else {

							//レーンごとにアイテムを生成
							for (int j = -1; j < 2; j++) {
									//アイテムの種類を決める
									int item = Random.Range (1, 11);
									//アイテムを置くZ座標のオフセットをランダムに設定
									int offsetZ = Random.Range(-5, 6);
									//60%コイン配置:30%車配置:10%何もなし
									if (1 <= item && item <= 6) {
											//コインを生成
											GameObject coin = Instantiate (coinPrefab) as GameObject;
											coin.transform.position = new Vector3 (posRange * j, coin.transform.position.y, targetPos + offsetZ);
									} else if (7 <= item && item <= 9) {
											//車を生成
											GameObject car = Instantiate (carPrefab) as GameObject;
											car.transform.position = new Vector3 (posRange * j, car.transform.position.y, targetPos + offsetZ);
									}
							}
					}
				}

				this.generatePos = this.generatePos + this.generateInterval;
			}
        }
}

using UnityEngine;
using System.Collections;

//<summary>
//Game object, that creates maze and instantiates it in scene
//</summary>
public class LabirintSpawner : MonoBehaviour {
	public enum AlgoritamZaGenerisanjeLabirinta{
		Rekurzivni,
		RandomStablo,
		RekurzivnaPodjela,
	}

	public AlgoritamZaGenerisanjeLabirinta algoritam = AlgoritamZaGenerisanjeLabirinta.Rekurzivni;
	/*public bool FullRandom = false;
	public int RandomSeed = 12345;*/
	public GameObject pod = null;
	public GameObject zid = null;
	public GameObject stub = null;
	public int redovi = 5;
	public int kolone = 5;
	public float sirinaCelije = 5;
	public float visinaCelije = 5;
	public bool dodajPraznine = false;
	public GameObject ciljniObjekat = null;

	private GeneratorLabirinta generatorLabirinta = null;

	void Start () {
		/*if (!FullRandom) {
			Random.seed = RandomSeed;
		}*/
		switch (algoritam) {
		case AlgoritamZaGenerisanjeLabirinta.Rekurzivni:
			generatorLabirinta = new RekurzivniGeneratorLabirinta (redovi, kolone);
			break;
		case AlgoritamZaGenerisanjeLabirinta.RandomStablo:
			generatorLabirinta = new RandomStabloGeneratorLabirinta (redovi, kolone);
			break;
		case AlgoritamZaGenerisanjeLabirinta.RekurzivnaPodjela:
			generatorLabirinta = new DivisionGeneratorLabirinta (redovi, kolone);
			break;
		}
		generatorLabirinta.GenerateMaze ();
		for (int red = 0; red < redovi; red++) {
			for(int kolona = 0; kolona < kolone; kolona++){
				float x = kolona*(sirinaCelije+(dodajPraznine?.2f:0));
				float z = red*(visinaCelije+(dodajPraznine?.2f:0));
				CelijaLabirinta celija = generatorLabirinta.GetMazeCell(red,kolona);
				GameObject tmp;
				tmp = Instantiate(pod,new Vector3(x,0,z), Quaternion.Euler(0,0,0)) as GameObject;
				tmp.transform.parent = transform;
				if(celija.WallRight){
					tmp = Instantiate(zid,new Vector3(x+sirinaCelije/2,0,z)+zid.transform.position,Quaternion.Euler(0,90,0)) as GameObject;// desni
					tmp.transform.parent = transform;
					
				}
				if(celija.WallFront){
					tmp = Instantiate(zid,new Vector3(x,0,z+visinaCelije/2)+zid.transform.position,Quaternion.Euler(0,0,0)) as GameObject;// gornji
					tmp.transform.parent = transform;
				}
				if(celija.WallLeft){
					tmp = Instantiate(zid,new Vector3(x-sirinaCelije/2,0,z)+zid.transform.position,Quaternion.Euler(0,270,0)) as GameObject;// lijevi
					tmp.transform.parent = transform;
				}
				if(celija.WallBack){
					tmp = Instantiate(zid,new Vector3(x,0,z-visinaCelije/2)+zid.transform.position,Quaternion.Euler(0,180,0)) as GameObject;// donji
					tmp.transform.parent = transform;
				}
				if( red==redovi-1 && kolona==kolone-1 && ciljniObjekat != null){//celija.IsGoal
					tmp = Instantiate(ciljniObjekat,new Vector3(x,1,z), Quaternion.Euler(0,0,0)) as GameObject;
					tmp.transform.parent = transform;
				}
			}
		}
		if(stub != null){
			for (int red = 0; red < redovi+1; red++) {
				for (int kolona = 0; kolona < kolone+1; kolona++) {
					float x = kolona*(sirinaCelije+(dodajPraznine?.2f:0));
					float z = red*(visinaCelije+(dodajPraznine?.2f:0));
					GameObject tmp = Instantiate(stub,new Vector3(x-sirinaCelije/2,0,z-visinaCelije/2),Quaternion.identity) as GameObject;
					tmp.transform.parent = transform;
				}
			}
		}
	}
}

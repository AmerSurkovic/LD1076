using UnityEngine;
using System.Collections;

//<summary>
//Sublcass for selecting random cell from container
//</summary>
public class RandomStabloGeneratorLabirinta : StabloGeneratorLabirinta {

	public RandomStabloGeneratorLabirinta(int row, int column):base(row,column){
		
	}
	
	protected override int GetCellInRange(int max)
	{
		return Random.Range (0, max+1);
	}
}

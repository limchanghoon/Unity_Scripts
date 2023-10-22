using System;
using System.Collections;
using System.Collections.Generic;

public class TuningRecipe
{
    public string[] material_name;
    public int[] material_count;

    public TuningRecipe(int _level)
    {
        if (_level < 10)
        {
            material_name = new string[] { "Stone_0" };
            material_count = new int[] { _level };
        }
        else if (_level < 20)
        {
            material_name = new string[] { "Stone_0", "Stone_1" };
            material_count = new int[] { (int)(_level * 1.5f), _level - 9 };
        }
        else if (_level < 30)
        {
            material_name = new string[] { "Stone_0", "Stone_1" };
            material_count = new int[] { (int)(_level * 1.5f), _level };
        }
        else
        {
            material_name = new string[] { "Stone_0", "Stone_1", "Stone_2" };
            material_count = new int[] { _level * 2, (int)(_level * 1.5f), _level - 29 };
        }
    }
}

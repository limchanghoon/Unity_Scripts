using System;
using System.Collections;
using System.Collections.Generic;

public class TuningRecipe
{
    public string name;
    public int level;
    public string[] material_name;
    public int[] material_count;

    public TuningRecipe(string _name, int _level, string[] _material_name, int[] _material_count)
    {
        name = _name;
        level = _level;
        material_name = _material_name;
        material_count = _material_count;
    }
}

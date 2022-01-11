using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleDatebase:BaseDatebase
{
    public string Name;
    public string Des;
}


public class RoleTable:ConfigTable<RoleDatebase,RoleTable>
{
    public RoleTable()
    {
        LoadTable("Config/table.csv");
    }

    protected override void ReadDate(RoleDatebase datebase, string[] itemStrArray)
    {
        datebase.Name = itemStrArray[1];
    }

}

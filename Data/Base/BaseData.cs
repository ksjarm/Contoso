﻿namespace Contoso.Data.Base;
public abstract class BaseData : IEntity {
    public int ID { get; set; }
    public DateTime ValidFrom { get; set; }
    public DateTime ValidTo { get; set; }
}
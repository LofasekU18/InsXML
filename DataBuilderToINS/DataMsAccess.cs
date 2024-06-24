namespace InsXml;

class DataMsAccess
{
    public string MyProperty { get; set; }
    public string MyProperty2 { get; set; }
    public string MyProperty3 { get; set; }

    public override string ToString()
    {
        return $"{MyProperty} {MyProperty2} {MyProperty3}";
    }
}




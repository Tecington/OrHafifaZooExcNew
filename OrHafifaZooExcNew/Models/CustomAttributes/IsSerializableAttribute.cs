namespace OrHafifaZooExcNew.Models.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class IsSerializableAttribute : Attribute
    {
        public bool IsSerializable { get; }

        public IsSerializableAttribute(bool isSerializable)
        {
            this.IsSerializable = isSerializable;
        }
    }
}
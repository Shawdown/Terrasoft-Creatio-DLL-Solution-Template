namespace DllDescriptorJsonGenerator
{
    using System;

    /// <summary>
    /// Модель корневого объекта в файле "descriptor.json".
    /// </summary>
    internal class DescriptorJsonModel
    {
        public DescriptorModel Descriptor { get; set; }
    }

    /// <summary>
    /// Модель объекта "Descriptor" в корневом объекте.
    /// </summary>
    internal class DescriptorModel
    {
        public Guid UId { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public DateTime ModifiedOnUtc { get; set; }
    }
}
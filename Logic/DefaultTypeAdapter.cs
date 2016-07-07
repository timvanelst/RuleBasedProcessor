using Domain;

namespace Logic
{
    public interface ITypeAdapter
    {
        ItemType? CreateOrDefault(string typeReference);
    }

    public class DefaultTypeAdapter : ITypeAdapter
    {
        public ItemType? CreateOrDefault(string typeReference)
        {
            switch (typeReference.ToLower().Trim())
            {
                case "in":
                case "inkpl":
                    return ItemType.In;
                case "uit":
                case "out":
                    return ItemType.Out;
                case "in_gate":
                    return ItemType.OnPremises;
                case "out_gate":
                    return ItemType.OffPremises;
                default:
                    throw new BusinessException(string.Format("Onbekend type {0}", typeReference));
            }
        }
    }
}
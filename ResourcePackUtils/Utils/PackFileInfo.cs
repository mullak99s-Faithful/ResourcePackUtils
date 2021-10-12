namespace ResourcePackUtils.Utils
{
    public class PackFileInfo
    {
        public PackFileType FileType { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
    }

    public enum PackFileType
    {
        BLOCK,
        ITEM,
        ENTITY,
        GUI,
        MAP,
        MISC,
        MOB_EFFECT,
        MODELS,
        PAINTING,
        PARTICLE,
        CTM,
        COLORMAP,
        EFFECT,
        ENVIRONMENT,
        FONT,
        REALMS,
        OPTIFINE_CTM,
        OTHER_MC = 9998,
        OTHER = 9999
    }
}

namespace SummerSchoolGUI.Domain.ValueObjects
{
    public record TransformComponent : IComponent
    {
        public float posX;
        public float posY;
        public float rotX;
        public float rotY;
        public float scaleX = 10;
        public float scaleY = 10;

        public IComponent Copy()
        {
            return new TransformComponent
            {
                posX = this.posX,
                posY = this.posY,
                rotX = this.rotX,
                rotY = this.rotY,
                scaleX = this.scaleX,
                scaleY = this.scaleY
            };
        }
    }
}

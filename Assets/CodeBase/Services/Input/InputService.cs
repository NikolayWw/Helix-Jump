namespace CodeBase.Services.Input
{
    public class InputService : IInputService
    {
        public float RotateAxis => UnityEngine.Input.GetAxis("Horizontal");
    }
}
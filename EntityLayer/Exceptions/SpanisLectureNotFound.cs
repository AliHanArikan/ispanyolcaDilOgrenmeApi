namespace EntityLayer.Exceptions
{
    public sealed class SpanisLectureNotFound : NotFound
    {
        public SpanisLectureNotFound(int id) : base($"The lecture with id: {id} could not found")
        {

        }
    }
}

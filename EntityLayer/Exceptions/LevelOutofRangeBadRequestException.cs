namespace EntityLayer.Exceptions
{
    public class LevelOutofRangeBadRequestException : BadRequestException
    {
        public LevelOutofRangeBadRequestException()
            : base("Ust level dörtten küçük birden büyük olmalı ")
        {

        }
    }
}

namespace LearningExperience.Domain.ValueObjects
{
    //TO-DO - Corrigir os status code no Ionic, inutilizando este enum
    public enum ReturnStatusCode
    {
        Ok = 200,
        Created = 201,
        NotAuthorized = 401,
        InternalServerError = 500
    }
}

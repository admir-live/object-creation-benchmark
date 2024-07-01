namespace Corr2.Notification.PoC.Entities;

public class Result
{
    public Guid Id { get; set; }
    public string Customer { get; set; }
    public string SampleForm { get; set; }
    public string SampleType { get; set; }
    public string Test { get; set; }
    public decimal QntResult { get; set; }
    public decimal QltResult { get; set; }
    public bool IsSuccess { get; set; }

    public class Builder
    {
        private readonly Result _result = new();

        public Builder WithId(Guid id)
        {
            _result.Id = id;
            return this;
        }

        public Builder WithCustomer(string customer)
        {
            _result.Customer = customer;
            return this;
        }

        public Builder WithSampleForm(string sampleForm)
        {
            _result.SampleForm = sampleForm;
            return this;
        }

        public Builder WithSampleType(string sampleType)
        {
            _result.SampleType = sampleType;
            return this;
        }

        public Builder WithTest(string test)
        {
            _result.Test = test;
            return this;
        }

        public Builder WithQntResult(decimal qntResult)
        {
            _result.QntResult = qntResult;
            return this;
        }

        public Builder WithQltResult(decimal qltResult)
        {
            _result.QltResult = qltResult;
            return this;
        }

        public Builder WithIsSuccess(bool isSuccess)
        {
            _result.IsSuccess = isSuccess;
            return this;
        }

        public Result Build()
        {
            return _result;
        }
    }
}

using Wpm.Clinic.Domain.ValueObjects;
using Wpm.SharedKernel;

namespace Wpm.Clinic.Domain;

public class Consultation : AggregateRoot
{
    private readonly List<DrugAdministration> administredDrugs = new(); 
    private readonly List<VitalSigns> vitalSignReadings = new();
    public DateTime StartedAd { get; init; }
    public DateTime? EndedAt { get; private set; }
    public Text Diagnosis { get; private set; }
    public Text Treatment { get; private set; }
    public PatientId PatientId { get; init; }
    public Weight CurrentWeight { get; private set; }
    public ConsultationStatus Status { get; private set; }
    public IReadOnlyCollection<DrugAdministration> AdministredDrugs => administredDrugs;
    public IReadOnlyCollection<VitalSigns> VitalSignReadings => vitalSignReadings;

    public Consultation(PatientId patientId)
    {
        Id = Guid.NewGuid();
        PatientId = patientId;
        Status = ConsultationStatus.Open;
        StartedAd = DateTime.UtcNow;
    }
    public void RegisterVitalSigns(IEnumerable<VitalSigns> vitalSigns)
    {
        ValidateConsultationStatus();
        vitalSignReadings.AddRange(vitalSigns);
    }
    public void AdministerDrug(DrugId drugId, Dose dose)
    {
        ValidateConsultationStatus();
        var  newDrugadministration= new DrugAdministration(drugId, dose);
        administredDrugs.Add(newDrugadministration);
    }
    public void End()
    {
        ValidateConsultationStatus();
        if(Diagnosis == null || Treatment == null || CurrentWeight == null)
        {
            throw new InvalidOperationException("Consultation cannot be ended.");
        }
        Status = ConsultationStatus.Closed;
        EndedAt = DateTime.UtcNow;
    }

    public void SetWeiight(Weight weight)
    {
        ValidateConsultationStatus();
        CurrentWeight = weight;
    }
    public void SetDiagnosis(Text diagnosis)
    {
        ValidateConsultationStatus();
        Diagnosis = diagnosis;
    }
    public void SetTreatment(Text treatment)
    {
        ValidateConsultationStatus();
        Treatment = treatment;
    }

    private void ValidateConsultationStatus()
    {
       if (Status == ConsultationStatus.Closed)
        {
            throw new InvalidOperationException("Consultation is closed.");
        }
    }
}
public enum ConsultationStatus
{
    Open,
    Closed
}

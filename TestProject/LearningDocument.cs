namespace TestProject;

public record LearningDocument(
    string? Id,
    string? DocumentId,
    DocumentType Type,
    DocumentStatus Status,
    int Version,
    IEnumerable<Section> Sections,
    IEnumerable<UserAssignment> UserAssignments,
    User? CreatedBy,
    DateTime? CreatedAt,
    DateTime? PublishedAt,
    User? DeletedBy,
    DateTime? DeletedAt,
    IEnumerable<DocumentHistoryItem> History,
    bool CommentsEnabled,
    PublishedContent Content,
    bool Historic = false,
    bool ActiveDocument = true);

public record PublishedContent(
    string? Title,
    string? LearningType,
    string? Organisation,
    IEnumerable<Metadata> Metadata,
    IEnumerable<FileAttachment>? Attachments,
    IEnumerable<Incident> Incidents,
    IEnumerable<AttachmentFile>? Files = null)
{
    public IEnumerable<FileAttachment> Attachments { get; init; } = Attachments ?? Enumerable.Empty<FileAttachment>();
}

public record AttachmentFile(string Path);

public enum AssignmentRole { Creator, Reviewer, Approver, Legal, SME }

public enum DocumentType { LI, LA, HVL }

public enum DocumentStatus { Create, Review, Approve, Publish }

public record SectionAssignment(string SectionName, bool Completed);
public record LearningPointAssignment(string Id, bool Completed);

public record UserAssignment(
    User User,
    AssignmentRole Role,
    IEnumerable<SectionAssignment>? Sections,
    IEnumerable<LearningPointAssignment>? LearningPoints,
    DateTime? CompletedAt = null)
{
    public IEnumerable<SectionAssignment> Sections { get; init; } = Sections ?? Enumerable.Empty<SectionAssignment>();
    public IEnumerable<LearningPointAssignment> LearningPoints { get; init; } = LearningPoints ?? Enumerable.Empty<LearningPointAssignment>();

}

public record User(
    string Id,
    string Mail,
    string GivenName,
    string Surname,
    string? JobTitle);

public record Comment(
    Guid Id,
    User User,
    string Text,
    IEnumerable<User>? Assignees,
    DateTime CreatedAt,
    DateTime? UpdatedAt = null);

public record Incident(
    string Id,
    string Hex,
    string Date,
    string Source,
    string Country,
    string Location,
    IEnumerable<string>? OrganizationTierNames,
    IEnumerable<Metadata> Metadata,
    int Order);

public record Location(
    int Id,
    string Name,
    string Type,
    int? Parent,
    IEnumerable<int> Children
    );

public record DocumentHistoryItem(
    User User,
    string Message,
    int Version,
    DocumentStatus Status,
    DateTime CreatedAt);

public record RelatedDocument(
    string Id,
    string Date,
    string DocumentId,
    string Type,
    IEnumerable<Metadata> Metadata,
    int Order);

public record FileAttachment(
    string Name,
    long Size,
    string Description,
    DateTime CreatedAt,
    User CreatedBy);

//TODO: simplify the contract to keep the ExternalId only; The FE will resolve the actual values using the endpoint
public record Metadata(
    int Id,
    string? ExternalId,
    string? Category,
    int? CategoryNumber,
    string Name,
    string? Code,
    string DataType);

public record LearningPoint(
    Guid Id,
    int Order,
    string Title,
    string Description,
    IEnumerable<FileAttachment> Attachments,
    IEnumerable<Metadata> Metadata,
    IEnumerable<Comment> Comments,
    string? ResponsibleParty,
    DateTime? DueDate,
    string? CompletionEvidence,
    bool RiskEventSelected = false,
    bool RiskBarrierSelected = false,
    bool OmsSelected = false,
    bool LsrSelected = false,
    bool PfsSelected = false,
    bool SlpSelected = false,
    bool PifSelected = false,
    bool OmsPracticesSelected = false);

public record Section(
    int Order,
    string Name,
    IEnumerable<Comment> Comments,
    IEnumerable<VersionInfo> Versions);

public record VersionInfo(
    int? Version,
    User CreatedBy,
    DateTime CreatedAt,
    VersionData Data);

public record VersionData(
    string? Title = "",
    string? Text = "",
    string? Organisation = null,
    DateTime? Date = null,
    FileAttachment? Attachment = null,
    IEnumerable<FileAttachment>? Attachments = null,
    Incident? MainIncident = null,
    IEnumerable<Incident>? Incidents = null,
    IEnumerable<RelatedDocument>? RelatedDocuments = null,
    IEnumerable<LearningPoint>? LearningPoints = null,
    IEnumerable<Metadata>? Metadata = null,
    IEnumerable<User>? NotifyList = null,
    IEnumerable<User>? TechnicalQuestions = null,
    IEnumerable<User>? Feedback = null)
{
    public IEnumerable<FileAttachment> Attachments { get; init; } = Attachments ?? Enumerable.Empty<FileAttachment>();
    public IEnumerable<Incident> Incidents { get; init; } = Incidents ?? Enumerable.Empty<Incident>();
    public IEnumerable<RelatedDocument> RelatedDocuments { get; init; } = RelatedDocuments ?? Enumerable.Empty<RelatedDocument>();
    public IEnumerable<LearningPoint> LearningPoints { get; init; } = LearningPoints ?? Enumerable.Empty<LearningPoint>();
    public IEnumerable<Metadata> Metadata { get; init; } = Metadata ?? Enumerable.Empty<Metadata>();
    public IEnumerable<User> NotifyList { get; init; } = NotifyList ?? Enumerable.Empty<User>();
    public IEnumerable<User> TechnicalQuestions { get; init; } = TechnicalQuestions ?? Enumerable.Empty<User>();
    public IEnumerable<User> Feedback { get; init; } = Feedback ?? Enumerable.Empty<User>();
}

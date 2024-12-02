async function editMedicalReportAsync(report) {
    const url = `/MedicalReportView/${report.admissionId}?handler=Edit`;

    const response = await fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            "RequestVerificationToken": $('input:hidden[name="__RequestVerificationToken"]').val()
        },
        body: JSON.stringify(report)
    });

    const data = await response.json();

    return data;
}

async function deleteMedicalReportAsync(report) {
    const url = `/MedicalReportView/${report.admissionId}?handler=Delete&reportId=${report.id}`;

    const response = await fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            "RequestVerificationToken": $('input:hidden[name="__RequestVerificationToken"]').val()
        },
    });

    const data = await response.json();

    return data;
}
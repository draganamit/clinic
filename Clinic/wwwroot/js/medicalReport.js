async function editReport(id) {
    const formId = 'medicalReportFormCard_' + id;

    const model = getMedicalReportFormModel(formId);

    const response = await editMedicalReportAsync(model);

    if (response.success) {
        setEditStyle(formId);
    }
}

async function deleteReport(id) {
    const formId = 'medicalReportFormCard_' + id;

    const model = getMedicalReportFormModel(formId);

    const response = await deleteMedicalReportAsync(model);
    if (response.success) {
        deleteReportCard(formId)
    }
}

function deleteReportCard(formId) {
    const formElement = document.getElementById(formId);
    if (formElement) {
        const formGrandParent = formElement.parentElement?.parentElement;
        if (formGrandParent) {
            formGrandParent.remove()
        }
    }
}
function setEditStyle(formId) {
    const formElement = document.getElementById(formId);
    if (formElement) {
        const editReportMessage = formElement.querySelector("#editReportMessage")
        if (editReportMessage) {
            editReportMessage.innerHTML = "Uspješno izmjenjeno.";
            editReportMessage.hidden = false;
            formElement.querySelectorAll('#createdAt, #hours, #minutes, #reportDescription').forEach(el => {
                el.addEventListener('input', function () {
                    editReportMessage.hidden = true;
                })
            })
        }
    }
}
function getMedicalReportFormModel(formId) {
    const singleReport = document.getElementById(formId);

    const id = singleReport.querySelector('#id').value;
    const admissionId = singleReport.querySelector('#admissionId').value;
    const reportDescription = singleReport.querySelector('#reportDescription').value;
    const createdAt = singleReport.querySelector('#createdAt').value;
    const hours = singleReport.querySelector('#hours').value;
    const minutes = singleReport.querySelector('#minutes').value;

    return {
        id,
        admissionId,
        reportDescription,
        createdAt,
        hours,
        minutes
    }
}
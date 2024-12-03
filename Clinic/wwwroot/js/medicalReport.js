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
            formElement.querySelectorAll('#createdAt, #hours, #minutes, #reportDescription').forEach(el => {
                el.disabled = true;
            })
            const editButton =  formElement.querySelector("#editButton")
            const saveButton = formElement.querySelector("#saveButton")
            editButton.removeAttribute("hidden");
            saveButton.setAttribute("hidden", "");
        }
}

function enableButtons(id) {

    const formId = 'medicalReportFormCard_' + id;
    const formElement = document.getElementById(formId);
    if (formElement) {

        const editButton = formElement.querySelector("#editButton")
        const saveButton = formElement.querySelector("#saveButton")
        editButton.setAttribute("hidden", "")
        saveButton.removeAttribute("hidden")

    formElement.querySelectorAll('#createdAt, #hours, #minutes, #reportDescription').forEach(el => {
        el.disabled = false;
    })
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

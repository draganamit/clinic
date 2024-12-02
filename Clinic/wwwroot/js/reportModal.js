var myModal;
document.addEventListener('DOMContentLoaded', function () {
    myModal = new bootstrap.Modal(document.getElementById("reportModal", {}));

    var modalElement = document.getElementById('reportModal');
    modalElement.addEventListener('hidden.bs.modal', function (event) {
        resetModel();
    });
})

function openModal() {
    if (myModal) {
        myModal.show();
    }
}

function hideModal() {
    if (myModal) {
        myModal.hide();
        resetModel();
    }
}

async function submitMedicalReport() {
    const reportModel = getModel()
    const response = await fetch(`/AddAdmission/${reportModel.admissionId}?handler=AddMedicalReport`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            "RequestVerificationToken": $('input:hidden[name="__RequestVerificationToken"]').val()
        },
        body: JSON.stringify(reportModel),
    });

    if (response.ok) {
        const data = await response.text();

        if (reportModel.id > 0) {
            document.getElementById(`card_${reportModel.id}`).outerHTML = data;
        }
        else {
            const reportsList = document.getElementById('reportsList');

            reportsList.innerHTML = `${data}${reportsList.innerHTML}`;
        }
        hideModal();
    } else {
        alert('Došlo je do greške prilikom dodavanja nalaza.');
    }
}

function getModel() {
    const reportModal = document.getElementById("reportModal");

    const id = reportModal.querySelector('#reportId').value;
    const admissionId = reportModal.querySelector('#admissionId').value;
    const reportDescription = reportModal.querySelector('#reportDescription').value;
    const createdAt = reportModal.querySelector('#reportCreatedAt').value;

    return {
        id,
        admissionId,
        reportDescription,
        createdAt
    }
}

function resetModel() {
    const date = new Date();
    const formattedDate = date.toISOString().split('T')[0];

    const reportModal = document.getElementById("reportModal");
    const id = reportModal.querySelector('#reportId').value = 0;
    const reportDescription = reportModal.querySelector('#reportDescription').value = "";
    const createdAt = reportModal.querySelector('#reportCreatedAt').value = formattedDate;
}
document.getElementById('availabilityForm').addEventListener('submit', async function (e) {
    e.preventDefault();

    const teacherId = document.getElementById('teacherId').value;
    const dayOfWeek = document.getElementById('dayOfWeek').value;
    const startHour = document.getElementById('startHour').value;
    const endHour = document.getElementById('endHour').value;

    const data = {
        teacherId: parseInt(teacherId),
        dayOfWeek: dayOfWeek,
        startHour: parseInt(startHour),
        endHour: parseInt(endHour)
    };

    try {
        const response = await fetch('/api/teachers/availability', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        });

        if (response.ok) {
            alert('Availability saved successfully!');
            loadSchedule(teacherId);
        } else {
            alert('Failed to save availability.');
        }
    } catch (error) {
        console.error('Error:', error);
        alert('An error occurred.');
    }
});

async function loadSchedule(teacherId) {
    const scheduleDisplay = document.getElementById('scheduleDisplay');
    scheduleDisplay.innerHTML = '';

    try {
        const response = await fetch(`/api/schedules/${teacherId}`);
        const schedules = await response.json();

        schedules.forEach(schedule => {
            const div = document.createElement('div');
            div.textContent = `Day: ${schedule.dayOfWeek}, Hours: ${schedule.startHour} - ${schedule.endHour}`;
            scheduleDisplay.appendChild(div);
        });
    } catch (error) {
        console.error('Error:', error);
        scheduleDisplay.textContent = 'Failed to load schedule.';
    }
}
document.getElementById('availabilityForm').addEventListener('submit', async function (e) {
    e.preventDefault();

    const teacherId = document.getElementById('teacherId').value;
    const dayOfWeek = document.getElementById('dayOfWeek').value;
    const startHour = document.getElementById('startHour').value;
    const endHour = document.getElementById('endHour').value;

    const data = {
        teacherId: parseInt(teacherId),
        dayOfWeek: dayOfWeek,
        startHour: parseInt(startHour),
        endHour: parseInt(endHour)
    };

    try {
        const response = await fetch('/api/teachers/availability', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        });

        if (response.ok) {
            alert('Availability saved successfully!');
            loadSchedule(teacherId);
        } else {
            alert('Failed to save availability.');
        }
    } catch (error) {
        console.error('Error:', error);
        alert('An error occurred.');
    }
});

async function loadSchedule(teacherId) {
    const scheduleDisplay = document.getElementById('scheduleDisplay');
    scheduleDisplay.innerHTML = '';

    try {
        const response = await fetch(`/api/schedules/${teacherId}`);
        const schedules = await response.json();

        schedules.forEach(schedule => {
            const div = document.createElement('div');
            div.textContent = `Day: ${schedule.dayOfWeek}, Hours: ${schedule.startHour} - ${schedule.endHour}`;
            scheduleDisplay.appendChild(div);
        });
    } catch (error) {
        console.error('Error:', error);
        scheduleDisplay.textContent = 'Failed to load schedule.';
    }
}

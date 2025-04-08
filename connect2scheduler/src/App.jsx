import React, { useEffect, useState } from "react";
import axios from "axios";
import './App.css'

function App() {

  const [tasks, setTasks] = useState([]);

    useEffect(() => {
        axios.get("/api/tasks")
            .then(response => setTasks(response.data))
            .catch(error => console.error("Error fetching tasks:", error));
    }, []);

    return (
        <div>
            <h1>Task Scheduler</h1>
            <ul>
                {tasks.map((task, index) => (
                    <li key={index}>{task}</li>
                ))}
            </ul>
        </div>
    );
}

export default App


import React from "react";
import "./Styles/Login.css";
import { useNavigate } from "react-router-dom";

function Login() {
    const navigate = useNavigate(); // Use navigate hook for routing

    const handleLogin = (event) => {
        event.preventDefault(); // Prevent the default form submission behavior
        console.log("Login button clicked");
        navigate("/home"); // Redirect to the home page after login
    };

    return (
        <div className="login-container">
            <div className="heading">
                <h1>Connect 2 Scheduler</h1>
                <p>Task scheduler is in control.</p>
            </div>
            <form>
                <div>
                    <label htmlFor="username">Username</label>
                    <input type="text" id="username" name="username" />
                </div>
                <br />

                <div>
                    <label htmlFor="password">Password</label>
                    <input type="password" id="password" name="password" />
                </div>
                <br />

                <button type="submit" onClick={handleLogin}>Login</button>
            </form>
        </div>
    );
}

export default Login;

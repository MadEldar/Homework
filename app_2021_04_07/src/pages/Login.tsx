import "../App.css";
import React, { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import axios from "axios";

export function Login() {
    const [userInfo, setUserInfo] = useState({
        username: "",
        password: "",
    });

    const [errors, setErrors] = useState({
        login: "",
        username: "",
        password: "",
    });

    const [validityOfField, setValidityOfField] = useState({
        username: true,
        password: true,
    });

    const [validated, setValidated] = useState(false);

    function usernameToLowerCase(e: any) {
        setUserInfo({
            username: e.target.value.toLowerCase(),
            password: userInfo.password,
        });
    }

    function ValidateField(e: any) {
        const target = e.target.name;
        const value = e.target.value;
        let message = "";

        switch (target) {
            case "username":
                if (value.length <= 2)
                    message = "Username needs to be longer than 2 characters";
                if (value.length > 22)
                    message = "Username cannot be longer than 22 characters";
                ChangeErrorMessage(target, message);
                break;
            case "password":
                if (value.length < 8)
                    message = "Password length cannot be shorter than 8";
                break;
            default:
                return;
        }

        setValidityOfField((pre) => {
            return { ...pre, [target]: message === "" };
        });
        setUserInfo((pre) => {
            return { ...pre, [target]: value };
        });
        ChangeErrorMessage(target, message);
    }

    useEffect(() => {
        setValidated(validityOfField.username && validityOfField.password);
    }, [validityOfField]);

    function ChangeErrorMessage(target: string, message: string) {
        setErrors((pre) => {
            return { ...pre, [target]: message };
        });
    }

    function handleSubmit(event: any) {
        event.preventDefault();
        axios
            .get(`http://localhost:3001/users?username=${userInfo.username}&password=${userInfo.password}`)
            .then((res) => res.data)
            .then((user) => {
                if (user.length > 0) {
                    const { username, email, gender } = user[0];

                    (async () => {
                        await axios.put(
                            "http://localhost:3001/currentUser",
                            { username: username, email: email, gender: gender }
                        );
                    })();
                } else {
                    ChangeErrorMessage(
                        "login",
                        "Credentials don't match with any user"
                    );
                }
            })
            .catch((err) => {
                console.log(err);
            });
    }

    return (
        <div className="container">
            <div className="row justify-content-center">
                <div className="col-12">
                    <h3 className="text-center">Login</h3>
                </div>
                <form onSubmit={handleSubmit} className="col-6">
                    <div className="col-12 mt-2">
                        <label htmlFor="username">Username</label>
                        <input
                            id="username"
                            name="username"
                            className={`form-control${
                                validityOfField.username ? "" : " invalid"
                            }`}
                            type="text"
                            value={userInfo.username}
                            onChange={(e) => {
                                usernameToLowerCase(e);
                                ValidateField(e);
                            }}
                        />
                        {errors.username && (
                            <div
                                className={
                                    validityOfField.username ? "" : "invalid"
                                }
                            >
                                {errors.username}
                            </div>
                        )}
                    </div>
                    <div className="col-12 mt-2">
                        <label htmlFor="password">Password</label>
                        <input
                            id="password"
                            name="password"
                            type="password"
                            className={`form-control${
                                validityOfField.password ? "" : " invalid"
                            }`}
                            value={userInfo.password}
                            onChange={ValidateField}
                        />
                        {errors.password && (
                            <div
                                className={
                                    validityOfField.password ? "" : "invalid"
                                }
                            >
                                {errors.password}
                            </div>
                        )}
                    </div>
                    <div className="container col-12 mt-3">
                        <div className="row justify-content-center">
                            <button
                                className="btn btn-primary"
                                type="submit"
                                disabled={!validated}
                            >
                                Submit
                            </button>
                            <Link
                                className="btn btn-outline-primary ml-2"
                                to="/home"
                            >
                                Return to home
                            </Link>
                            <div className="col-12 invalid mt-4 text-center">
                                {errors.login}
                            </div>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    );
}

export default Login;

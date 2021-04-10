import "../App.css";
import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { EmailRegex } from "../RegexStrings";
import axios from "axios";

export function Register() {
    const [userInfo, setUserInfo] = useState({
        username: "",
        password: "",
        email: "",
        gender: "male",
    });

    const [errors, setErrors] = useState({
        register: "",
        username: "",
        password: "",
        email: "",
    });

    const [validityOfField, setValidityOfField] = useState({
        username: false,
        password: false,
        email: false,
    });

    const [validated, setValidated] = useState(false);

    function usernameToLowerCase(e: any) {
        setUserInfo({
            username: e.target.value.toLowerCase(),
            password: userInfo.password,
            email: userInfo.email,
            gender: userInfo.gender,
        });
    }

    function handleSubmit(e: any) {
        e.preventDefault();
        (async () => {
            const existingUser = await axios
                .get(`http://localhost:3001/users?username=${userInfo.username}`)
                .then();
            if (existingUser.data.length !== 0) {
                ChangeErrorMessage(
                    "register",
                    "Username is already in use and must be unique"
                );
            } else {
                axios
                    .post("http://localhost:3001/users", { ...userInfo })
                    .then((res) => {
                        if (res.data) {
                        }
                    })
                    .catch((err) => console.log(err));
            }
        })();
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
                break;
            case "password":
                if (value.length < 8)
                    message = "Password length cannot be shorter than 8";
                break;
            case "email":
                if (!value.match(RegExp(EmailRegex)))
                    message = "Email is invalid";
                break;
            case "gender":
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
        setValidated(
            validityOfField.username &&
                validityOfField.password &&
                validityOfField.email
        );
    }, [validityOfField]);

    function ChangeErrorMessage(target: string, message: string) {
        setErrors((pre) => {
            return { ...pre, [target]: message };
        });
    }

    return (
        <div className="container">
            <div className="row justify-content-center">
                <div className="col-12">
                    <h3 className="text-center">Register</h3>
                </div>
                <form onSubmit={handleSubmit} className="col-6">
                    <div className="col-12 mt-2">
                        <label htmlFor="username">Username</label>
                        <input
                            id="username"
                            name="username"
                            className={`form-control${validityOfField.username ? "" : " invalid"}`}
                            type="text"
                            value={userInfo.username}
                            onChange={(e) => {
                                usernameToLowerCase(e);
                                ValidateField(e);
                            }}
                        />
                        {errors.username && (
                            <div className={validityOfField.username ? "" : "invalid"}>
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
                    <div className="col-12 mt-2">
                        <label htmlFor="email">Email</label>
                        <input
                            id="email"
                            name="email"
                            type="text"
                            className={`form-control${
                                validityOfField.email ? "" : " invalid"
                            }`}
                            value={userInfo.email}
                            onChange={ValidateField}
                        />
                        {errors.email && (
                            <div
                                className={
                                    validityOfField.email ? "" : "invalid"
                                }
                            >
                                {errors.email}
                            </div>
                        )}
                    </div>
                    <div className="col-12 mt-2">
                        <label htmlFor="gender">Gender</label>
                        <select
                            id="gender"
                            className="form-control"
                            name="gender"
                            value={userInfo.gender}
                            onChange={ValidateField}
                        >
                            <option value="male">Male</option>
                            <option value="female">Female</option>
                        </select>
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
                                {errors.register}
                            </div>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    );
}

export default Register;

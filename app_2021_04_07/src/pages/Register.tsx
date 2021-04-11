import "../App.css";
import { Link, useHistory } from "react-router-dom";
import { EmailRegex } from "../RegexStrings";
import axios from "axios";
import { useForm } from "react-hook-form";
import User from "../models/User";

export function Register() {
    const history = useHistory();
    const {
        register,
        handleSubmit,
        formState: { errors },
    } = useForm();

    function registerUser(data: User) {
        axios
            .get<User>(`http://localhost:3001/users?username=${data.username}`).then(res => {
                axios
                    .post("http://localhost:3001/users", data)
                    .then((res) => {
                        if (res.status === 201) {
                            history.push("/login");
                        }
                    });
                })
            .catch((err) => console.log(err));
    }

    return (
        <div className="container">
            <div className="row justify-content-center">
                <div className="col-12">
                    <h3 className="text-center">Register</h3>
                </div>
                <form onSubmit={handleSubmit(registerUser)} className="col-6">
                    <div className="col-12 mt-2">
                        <label htmlFor="username">Username</label>
                        <input
                            id="username"
                            className="form-control"
                            type="text"
                            {...register("username", {
                                required: "Username is required",
                                minLength: {
                                    value: 3,
                                    message: "Username length must be longer than 2 characters",
                                },
                                maxLength: {
                                    value: 22,
                                    message: "Product name length must not be longer than 22 characters",
                                },
                            })}
                            onChange={(e) => (e.target.value = e.target.value.toLowerCase())}
                        />
                        {errors.username && (
                            <div className={errors.username === "" ? "" : "invalid"}>
                                {errors.username.message}
                            </div>
                        )}
                    </div>
                    <div className="col-12 mt-2">
                        <label htmlFor="password">Password</label>
                        <input
                            id="password"
                            type="password"
                            className="form-control"
                            {...register("password", {
                                required: true,
                                minLength: {
                                    value: 8,
                                    message: "Password must have at least 8 characters",
                                },
                            })}
                        />
                        {errors.password && (
                            <div
                                className={errors.password === "" ? "" : "invalid"}>
                                {errors.password.message}
                            </div>
                        )}
                    </div>
                    <div className="col-12 mt-2">
                        <label htmlFor="email">Email</label>
                        <input
                            id="email"
                            type="text"
                            className="form-control"
                            {...register("email", {
                                required: true,
                                pattern: {
                                    value: EmailRegex,
                                    message: "This is not a valid email"
                                }
                            })}
                        />
                        {errors.email && (
                            <div className={errors.email === "" ? "" : "invalid"}>
                                {errors.email.message}
                            </div>
                        )}
                    </div>
                    <div className="col-12 mt-2">
                        <label htmlFor="gender">Gender</label>
                        <select
                            id="gender"
                            className="form-control"
                            {...register("gender")}
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
                            >
                                Submit
                            </button>
                            <Link
                                className="btn btn-outline-primary ml-2"
                                to="/home"
                            >
                                Return to home
                            </Link>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    );
}

export default Register;

import "../App.css";
import React, { useEffect, useState } from "react";
import { Link, useHistory } from "react-router-dom";
import axios from "axios";
import { useForm } from "react-hook-form";
import User from "../models/User";

export function Login() {
    const history = useHistory();
    const {
        register,
        handleSubmit,
        formState: { errors },
    } = useForm();

    function loginUser(data: User) {
        axios
            .get(`http://localhost:3001/users?username=${data.username}&password=${data.password}`)
            .then((res) => res.data)
            .then((user) => {
                const { username, email, gender } = user[0];

                return axios.put("http://localhost:3001/currentUser", {
                    username,
                    email,
                    gender,
                });
            })
            .then((res) => {
                if (res.status === 200) {
                    history.push("/home");
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
                <form onSubmit={handleSubmit(loginUser)} className="col-6">
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
                            onChange={(e) =>(e.target.value = e.target.value.toLowerCase())}
                        />
                        {errors.username}
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
                            <div className={ errors.password === "" ? "" : "invalid"}>
                                {errors.password.message}
                            </div>
                        )}
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

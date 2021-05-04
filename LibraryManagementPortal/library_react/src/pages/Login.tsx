import { useForm } from "react-hook-form";
import AlertMessage from "../models/AlertMessage";
import { Dispatch, SetStateAction } from "react";
import APICaller from "../services/APICaller.service";
import { setAuthToken } from "../helpers/LocalStorageHelper";
import StringResource from "../resources/StringResource";

export function Login({
    setAlertMessage,
}: {
    setAlertMessage: Dispatch<SetStateAction<AlertMessage>>;
}) {
    const {
        register,
        handleSubmit,
        formState: { errors },
    } = useForm();

    const onSubmit = async (data: { username: string; password: string }) => {
        let formData = new FormData();

        formData.append("username", data.username);
        formData.append("password", data.password);

        const response = await APICaller.postLogin(formData);

        if (response.statusCode === 200) {
            const token = response.headers.find(
                (h: { key: string; value: string[] }) =>
                    h.key === "AuthToken"
            ).value[0];
            
            setAuthToken(token);

            if (
                response.headers.find(
                    (h: { key: string; value: string[] }) =>
                        h.key === "Admin"
                )
            ) {
                localStorage.setItem("Admin", "true");
            }

            window.location.href = StringResource.linkHome;
        } else {
            setAlertMessage({
                message: response.reasonPhrase ?? "",
                type: "danger",
                statusCode: response.statusCode,
            });
        }
    };

    return (
        <div className="container center-aligned">
            <div className="row">
                <form className="col-5" onSubmit={handleSubmit(onSubmit)}>
                    <div className="form-group mt-3">
                        <label htmlFor="username">Username</label>
                        <input
                            id="username"
                            type="text"
                            placeholder="Username"
                            className="form-control"
                            {...register("username", {
                                required: "Username is required",
                                minLength: {
                                    value: 3,
                                    message:
                                        "Username length must be longer than 2 characters",
                                },
                            })}
                        />
                        {errors.username && (
                            <div
                                className={
                                    errors.username === "" ? "" : "invalid"
                                }
                                role="alert"
                            >
                                {errors.username.message}
                            </div>
                        )}
                    </div>
                    <div className="form-group mt-3">
                        <label htmlFor="password">Password</label>
                        <input
                            id="password"
                            type="password"
                            placeholder="Password"
                            className="form-control"
                            {...register("password", {
                                required: "Password is required",
                                minLength: {
                                    value: 7,
                                    message:
                                        "Password length must be longer than 6 characters",
                                },
                            })}
                        />
                        {errors.password && (
                            <div
                                className={
                                    errors.password === "" ? "" : "invalid"
                                }
                                role="alert"
                            >
                                {errors.password.message}
                            </div>
                        )}
                    </div>
                    <div className="row justify-content-center">
                        <button className="btn btn-primary mt-3" type="submit">
                            Login
                        </button>
                    </div>
                </form>
            </div>
        </div>
    );
}

export default Login;

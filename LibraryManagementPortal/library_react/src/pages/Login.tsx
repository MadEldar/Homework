import { Button, TextField } from "@material-ui/core";
import { useForm } from "react-hook-form";
import axios from "axios";
import ApiUrlBuiler from "../helpers/APIUrlBuiler";
import { useContext, useState } from "react";
import AppContext from "../AppContext";

export function Login() {
    const {
        register,
        handleSubmit,
        formState: { errors },
    } = useForm();
    const [user, setUser] = useState(AppContext);

    const onSubmit = async (data: { username: string; password: string }) => {
        const result = await axios({
            method: "post",
            url: ApiUrlBuiler.Login, // + `?username=${data.username}&password=${data.password}`
            data: data,
        }).then();

        const { reasonPhrase, statusCode } = result.data;

        if (statusCode === 200) {
            setUser(JSON.parse(reasonPhrase));
        }

        // if (result.data.statusCode)

        // if (result)
    };

    return (
        <div className="row">
            <form className="col-4 offset-4" onSubmit={handleSubmit(onSubmit)}>
                <TextField
                    type="text"
                    label="Username"
                    placeholder="Username"
                    className="mt-3"
                    fullWidth={true}
                    {...register("username", { required: true })}
                />
                <TextField
                    type="password"
                    label="Password"
                    placeholder="Password"
                    className="mt-3"
                    fullWidth={true}
                    {...register("password", { required: true })}
                />
                <div className="row justify-content-center">
                    <Button
                        variant="contained"
                        className="mt-3"
                        color="primary"
                        type="submit"
                    >
                        Login
                    </Button>
                </div>
            </form>
        </div>
    );
}

export default Login;

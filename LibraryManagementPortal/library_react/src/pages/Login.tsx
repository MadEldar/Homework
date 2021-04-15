import { Button, TextField } from "@material-ui/core";
import { useForm } from "react-hook-form";

export function Login() {
    const {
        register,
        handleSubmit,
        formState: { errors },
        watch,
    } = useForm();

    const onSubmit = (data: any) => {
        console.log(data);
    }

    console.log(watch("example"))

    return (
        <div className="row">
            <form className="col-4 offset-4" onSubmit={handleSubmit(onSubmit)}>
                <TextField
                    label="Username"
                    placeholder="Username"
                    className="mt-3"
                    fullWidth={true}
                    {...register("username", { required: true })}
                />
                <TextField
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

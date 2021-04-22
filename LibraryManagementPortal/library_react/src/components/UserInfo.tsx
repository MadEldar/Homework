import { useEffect, useState } from "react";
import User from "../models/User";
import APICaller from "../services/APICaller.service";

export function UserInfo() {
    const [user, setUser] = useState<User>({
        id: "",
        username: "",
        role: 0
    });

    useEffect(() => {
        (async () => {
            const currentUser: User = await APICaller.getCurrentUser();

            setUser(currentUser);
        })();
    }, []);

    return (
        <div className="container">
            <div className="row">
                <h3 className="col-12 my-3">User Information</h3>
                <div className="row col-6">
                    <div className="col-4">
                        <p>Username</p>
                    </div>
                    <div className="col-8">
                        <p>{user.username}</p>
                    </div>
                </div>
                <div className="row col-6">
                    <div className="col-4">
                        <p>Role</p>
                    </div>
                    <div className="col-8">
                        <p>{user.role}</p>
                    </div>
                </div>
            </div>
        </div>
    );
}

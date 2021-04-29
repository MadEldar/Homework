import { useEffect, useState } from "react";
import User from "../models/User";
import APICaller from "../services/APICaller.service";

export function UserInfo({ isAdmin }: { isAdmin: boolean }) {
    const [user, setUser] = useState<User>({
        id: "",
        username: "",
        role: 0,
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
                        <h5>Username</h5>
                    </div>
                    <div className="col-8">
                        <p>{user.username}</p>
                    </div>
                </div>
                {isAdmin ? (
                    <div className="row col-6">
                        <div className="col-4">
                            <h5>Role</h5>
                        </div>
                        <div className="col-8">
                            <p>{user.role === 0 ? "User" : "Admin"}</p>
                        </div>
                    </div>
                ) : (
                    <></>
                )}
            </div>
        </div>
    );
}

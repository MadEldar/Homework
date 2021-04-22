import { BookRequest } from "../components/BookRequest";
import { UserInfo } from "../components/UserInfo";

export function UserProfile() {
    return (
        <>
            <div className="col-12 container">
                <div className="row">
                    <UserInfo />
                </div>
            </div>
            <div className="col-12 container">
                <div className="row">
                    <BookRequest />
                </div>
            </div>
        </>
    );
}

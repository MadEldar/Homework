import { Descriptions } from "antd";
import axios, { AxiosResponse } from "axios";
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { PostInterface } from "./Posts";

export default function Post() {
    const [post, setPost] = useState<PostInterface>();
    const { id } = useParams<{ id: string }>();

    useEffect(() => {
        (async () => {
            const response: AxiosResponse = await axios.get(`https://jsonplaceholder.typicode.com/posts/${id}`);

            if (response.status === 200) {
                setPost(response.data);
            }
        })();
    }, []);

    return (
        <>
        <Descriptions>
            <Descriptions.Item label="User Id">
              {post?.userId}
            </Descriptions.Item>
            <Descriptions.Item label="Title" span={2}>
              {post?.title}
            </Descriptions.Item>
            <Descriptions.Item label="Id">
              {post?.id}
            </Descriptions.Item>
            <Descriptions.Item label="Body" span={2}>
              {post?.body}
            </Descriptions.Item>
          </Descriptions>
        </>
    )
}
import { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import Book from "../models/Book";
import Category from "../models/Category";
import APICaller from "../services/APICaller.service";
import {
    Form,
    Input,
    Button,
    Radio,
    Select,
    Cascader,
    DatePicker,
    InputNumber,
    TreeSelect,
    Switch,
} from "antd";

type SizeType = Parameters<typeof Form>[0]['size'];

export function BookFrom({ book, handler }: { book?: Book; handler: any }) {
    const [componentSize, setComponentSize] = useState<SizeType | 'default'>('default');
    const onFormLayoutChange = ({ size }: { size: SizeType }) => {
      setComponentSize(size);
    };
    const {
        register,
        handleSubmit,
        formState: { errors },
    } = useForm();
    const [categories, setCategories] = useState<Category[]>([]);

    useEffect(() => {
        (async () => {
            const allCategories = await APICaller.getAdminAllCategories().then();

            setCategories(allCategories);
        })();
    }, []);

    return (
        <Form
        labelCol={{ span: 4 }}
        wrapperCol={{ span: 14 }}
        layout="horizontal"
        initialValues={{ size: componentSize }}
        onValuesChange={onFormLayoutChange}
        size={componentSize as SizeType}
      >
        <Form.Item label="Form Size" name="size">
          <Radio.Group>
            <Radio.Button value="small">Small</Radio.Button>
            <Radio.Button value="default">Default</Radio.Button>
            <Radio.Button value="large">Large</Radio.Button>
          </Radio.Group>
        </Form.Item>
        <Form.Item label="Input">
          <Input />
        </Form.Item>
        <Form.Item label="Select">
          <Select>
            <Select.Option value="demo">Demo</Select.Option>
          </Select>
        </Form.Item>
        <Form.Item label="TreeSelect">
          <TreeSelect
            treeData={[
              { title: 'Light', value: 'light', children: [{ title: 'Bamboo', value: 'bamboo' }] },
            ]}
          />
        </Form.Item>
        <Form.Item label="Cascader">
          <Cascader
            options={[
              {
                value: 'zhejiang',
                label: 'Zhejiang',
                children: [
                  {
                    value: 'hangzhou',
                    label: 'Hangzhou',
                  },
                ],
              },
            ]}
          />
        </Form.Item>
        <Form.Item label="DatePicker">
          <DatePicker />
        </Form.Item>
        <Form.Item label="InputNumber">
          <InputNumber />
        </Form.Item>
        <Form.Item label="Switch">
          <Switch />
        </Form.Item>
        <Form.Item label="Button">
          <Button>Button</Button>
        </Form.Item>
      </Form>
    );

    // return (
    //     <Form
    //         className="col-6"
    //         onFinish={handleSubmit(handler)}
    //         initialValues={{
    //             title: book?.title,
    //             author: book?.author,
    //             category: book?.categoryId,
    //             id: book?.id,
    //         }}
    //     >
    //         <div className="col-12 form-group">
    //             <label htmlFor="title">Book title</label>
    //             <input
    //                 id="title"
    //                 type="text"
    //                 className="form-control"
    //                 // defaultValue={book?.title}
    //                 {...register("title", {
    //                     required: StringFormatter.validationForRequired(
    //                         "book title"
    //                     ),
    //                     minLength: {
    //                         value: 3,
    //                         message:
    //                             "Book title length must be longer than 2 characters",
    //                     },
    //                 })}
    //             />
    //             {errors.title && (
    //                 <div
    //                     className={errors.title === "" ? "" : "invalid"}
    //                     role="alert"
    //                 >
    //                     {errors.title.message}
    //                 </div>
    //             )}
    //         </div>
    //         <div className="col-12 form-group">
    //             <label htmlFor="author">Book author</label>
    //             <input
    //                 id="author"
    //                 type="text"
    //                 className="form-control"
    //                 // defaultValue={book?.author}
    //                 {...register("author", {
    //                     required: StringFormatter.validationForRequired(
    //                         "book author's name"
    //                     ),
    //                     minLength: {
    //                         value: 3,
    //                         message: StringFormatter.validationForMinLength(
    //                             "book author's name",
    //                             3
    //                         ),
    //                     },
    //                 })}
    //             />
    //             {errors.author && (
    //                 <div
    //                     className={errors.author === "" ? "" : "invalid"}
    //                     role="alert"
    //                 >
    //                     {errors.author.message}
    //                 </div>
    //             )}
    //         </div>
    //         <div className="col-12 form-group">
    //             <label htmlFor="category">Book category</label>
    //             <select
    //                 id="category"
    //                 className="form-control"
    //                 {...register("category")}
    //             >
    //                 {categories.map((c) => (
    //                     <option
    //                         key={c.id}
    //                         value={c.id}
    //                         selected={c.id === book?.categoryId}
    //                     >
    //                         {c.name}
    //                     </option>
    //                 ))}
    //             </select>
    //         </div>
    //         <div className="row justify-content-center col-12 form-group">
    //             <input
    //                 type="hidden"
    //                 defaultValue={book?.id}
    //                 {...register("id")}
    //             />
    //             <button className="btn btn-primary" type="submit">
    //                 Submit
    //             </button>
    //         </div>
    //     </Form>
    // );
}

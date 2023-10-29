using Amazon.S3;
using Amazon.S3.Model;
using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using Xunit;
using System.Net;
using NSubstitute;

public class ImageApiTests
{
    const string imageBase64 = "/9j/4AAQSkZJRgABAQAAAQABAAD/2wCEAAkGBxEQEhASEBASFRETEBUQFhISDxIQERAQFRcWGBcSExUYHiggGBolGxMTITEhJSkrMS4uFyE/ODMsQyotLi0BCgoKDQ0OFxAPFSsdFR0uKystKystOCsrKystLSw4LTctLS04KzgrKzc3Li4tKy0tOCstKy0rKystKysrKy0rK//AABEIAOEA4QMBIgACEQEDEQH/xAAcAAEAAQUBAQAAAAAAAAAAAAAABgIEBQcIAQP/xABFEAACAQIDBQQFBwoEBwAAAAAAAQIDEQQFIQYSMUFRBxNhcSIyQoGRM1JicqGxwRQjU2NzkqOys8IkJdHxFTRkdIKi4f/EABcBAQEBAQAAAAAAAAAAAAAAAAABAwL/xAAbEQEBAAIDAQAAAAAAAAAAAAAAARFBAjJCIf/aAAwDAQACEQMRAD8A3iAAAAAAAAAAAAAAAADE57tHhsFG9eqk7XVOPpVJeUfxdkauz/tRxVSVsKlRgnppGpUl9ZyTS8kvewNzg1rsT2jzrSVLHQSb9XEQVoN9KsfZ+stOqXE2DWx0ISjFu8pO1oreavzduCAuQeJnoAAAAAAAAAAAAAAAAAAAAAAAAAAAAW2Px9KhB1K1SMIL2pOy8l1fgjW+0valxhgo+HfVFr5wh+MvgBsPNs3oYWG/iKsYLld3lLwjFayfkaw2n7UKk96GDj3ceHeSs6rXguEPtfkQDH5jWxE3OpOU5vjKTbfl5eBThsG5PgEeVq1StJylKUpSd3KTcpN+LerMjluSyqNX4GUyzKoxs5nuZ5vCkrQAvXVo4OOlnKx9tldqZVpvDXalJtw3PXqx/Qp8YpavTVrS6S115mGYym22yywuMnSnCpTk41Kc1OMlylF3T+KJVdU5PQnTpQjUtdclwjHlH3F6YzZrNo43C4fExVlVpqTXzZ8Jx90lJe4yZQAAAAAAAAAAAAAAAAAAAAAACI7dbbQy10qSpudetGTpp6QtGyd2tW9VoviBKsRXhTi51JRjFK7lJqMUvFs1/tL2nUqd4YOPeS4d7NNU19WPGX2LzNb55tHicbK9eq5K+kF6NOH1YrT38fExqwzYFznGd18VNzrVJTlyu9I+EYrSK8iyhRci7pYSxk8Hgr6sIs8FlzlyM7RoQpK7KKuJhSXIjea5u53SegF/m2dcVHQjOIxLlxZ8ata58JSCjmfbCYadWcYQi5SlJRUUruUnokkfCnTcmkle75a3Zvzsv2EWDisTiY/4mUfRi18hB/3tcenDqBItgskngMDQw9RpzjvzlbVRlUnKbivLet8SQgAAAAAAAAAAAAAAAAAAAAAAAgfbDs3LGYLvaCvicJL8op2V5SivlIJLi2kmlzcUTwAc7YKEMZRhiKSW+1apBfPXFrx5+N/jXTp9DKbZZN/wXHd/TVsvxk3dLhQxDvJq3JcZLw3l7KK8Xhl8rDg9ZJcPrrw6/HqQYyEEuJTiswVNWRb4/MEr24kexmKcmUfXH5g5N6mNnUKJzPk2BU5Hi1PFqbO7KdgfyqUcXiof4eEvQpyWlea5tc4J/F6cmBhckyOphu4r16Mkqse8pqasqkOqfKVrNLjqmbr2UztVoxhKV5W9Cb41IrjGX01z68epls2yuliqUqVaO9B+6UJLhKD5SXU1hmmBq5XiIqTlOjLWFRJRk7atq3CrF69Gvfbi5lzpY24DFbPZr+UU9Wt+Nt62ikn6tSK6NcuTTXIyp3LlAAAAAAAAAAAAAAAAAAAAAAAAFhnuUUcbQq4evHep1I7r6xfFTi+Uk0mn1Ro7L41ssxU8uxbu16WHq2tGvRd7W8dHpyaa5K/QBGdvNkKeaUNxtQr0250K3OlU6O2rg7K68nxSA0jtflPctVaa/MzfD9HN+z9V8vh0ItKZsTKa85d9gcfT3cRTvTqU5e3H9JB8+TuvBogue5ZLC1pU5ar1oS+fB8H58n4ogsZMo4nnElmwWx9XMayirxpRtKrVtpCPRdZPkvfyKMj2a7DyzCp3lVNYWm1vy4OpLj3UH975LzR0Jh6MacYwhFRhGKjGMVaMYpWSS5I+OWZfTw1KFGjBRpwW7GK+99W+LZdADG7QZRDGUJ0Z6X9KMudOovVmvL7U2ZIAam2bzCrhK0qU42q0ZuLhf1ocZU11urTj/wDTatCtGcYzg04yipJrg4vVMhXaPlDShjaStOnaNS3Onf0Z+cW/g30RebEZsprun7SdSC6P24fF7y830M+Py4VLQAaIAAAAAAAAAAAAAAAAAAAAAAAAiG3+xizCEatFqnjqKvSq8FK2vdVGvZfXlfnqnqPOU8ZRqUa1N0sfhW26UlaTa9aMeqkrNW0vu62OiyN7W7F4bMd2U96niIepiaT3asPot+1HV6Pq7WuTA572S2cq4+vCjRWr1lJr0acFxnLw+/Q6V2dyOjgaEKFFejHVyfrVJ85yfV/YWmx+y1HLaTp0/SnN71Sq4pSqS5acoq+i8+rM8UAAAAAFFalGcZQmk4yi4yi9VKLVmn4WNT4WE8DiqlC73qNTfpt+3DjH96DcX7zbZB+0rL7Kji4LWnJUpv8AVyfoyflOy/8AM45z5lYmeFrxqQjOLvGUVJeTPqRbYXMN+E6TfqvvIr6E+K90r/vIlJ1LmZQABQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAALTN8EsRRrUXwqU5Qv0bWj9zs/cXYA1dsPi3TrUlLRuTozV+Dlpb9+MTaJqfOYOhjcUo6WrKtHXnJRqfzNm1qc1JJrg0n7mZ8NxaqABogAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAANb7dU9zGqXz8PB++Mpxf2bpN9nqu/hsPLn3UU/OKs/tRFO0iFquDkucK0X/Ca/Ez2xNTewlP6M6kf/eTX2NGc7VdM8ADRAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAQrtKWmEf6ya58HDw8kX/AGfyvhZft5r+Use0rhhP2k/5C+7Pv+Vf7ef9pn7XSTAA0QAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAEJ7TJ2WF0vaVWfG3CKX9xfdnkr4aV+PfSfG/rRhJclyaMb2lS9PCL6Fd/wBIvuzqX5muuldf06ZnO66SwAGiAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAUzqKPrNLzaQFQLSWaYdca9FedWC/E9p5jQl6tak/KrB/iBCe0yVq2D+pW++kX/Zw/QxX7dfyRMF2uYlRq4Bp6ONbg/GkZzszd6WJf/UL+nAz9qmQANEAAAAAAAAAAAAAAAAAAAAAAAAAAB5OSSbbskrtvRJLmzVu1Xa5Cm5QwEI1LXXf1L923+rgrOS8W0vMl3aRUccsxzTa/M7unSUkmvg2c3VHdXQEgzLbrMcQ3v4uqk/ZpS7mKXT83a/vuYpVu8d6s3J9Zycn8ZGP3WeOmv9wL/FRo20nC/hYx6ceqKnApdNAXuWzvNJPSz58DMUdtMdgajjh6zhG6coOMJxlLhdqSfJLhbgY/Z2nh+8/P98uNpUlCXLhJSa59Op89pqNHvp9w6so3d5VVCLfSyi2c7Gytnu2dtxjjcOvGpQumvF05PX3S9xtTJs3oYymquGqxqQel1xjLnGSesX4M5LjF3sbG7GsdOnmMaak9ytSmpx5S3IuUZNdU09fpPqdDfgAAAAAAAAAAAAAAAAAAAAAAAAAAivai/wDK8b9SC/iQOY3UcXo/9DqXb/LamKy/F0aKvUlTUox5zlCUZ7i8Xu295yvV4tNNNNppppprRpp8H4AfeON6r4H1jiYvn9hjj0DJqrH5yG/H5y+KMYLgZSNeMXfeXxKKuMi+rMaeMmBeSxb9lJfaya9jU/8ANcPfnCqv4ciARJ32OQk80w26m92NWUrezDu5LefheUV70UdJAAAAAAAAAAAAAAAAAAAAAAAAAAAQnbPszweYuVVXoYl8a1JJqb61ab0n56PxJsAOb877Is0w93ShDEw5OjNRnb6VOdtfBORD8flGJw7ar4avTtx7yjUgvi1ZnYB41fiBxipp818UVWOv8Rk2FqfKYahP61GnL70Y+exWVyd3l2Db/wC1pf6AcnSklxa+Je4DKcTiGlQw9arf9HRnNfFKx1fhdnsHS+SweHh9TD04v7EZKMUtErLotAOdtnex/McQ4vEKGFp89+SqVrfRpwdvjJG6tkNj8LldNww8W5yt3ladnVqtcLvktXaK0VyQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAP//Z";

    //UploadImage test
    [Fact]
    public async Task UploadImageTest()
    {
        IAmazonS3 mockS3Client = Substitute.For<IAmazonS3>();
        IAmazonRekognition rekognitionClient = Substitute.For<IAmazonRekognition>();

        //s3Client.PutObjectAsync returns HttpStatusCode.OK
        mockS3Client.PutObjectAsync(default, default)
            .ReturnsForAnyArgs(Task.FromResult(new PutObjectResponse { HttpStatusCode = HttpStatusCode.OK }));

        //rekognitionClient.DetectLabelsAsync returns a list of labels
        rekognitionClient.DetectLabelsAsync(default, default)
            .ReturnsForAnyArgs(Task.FromResult(new DetectLabelsResponse { Labels = new List<Label>{}}));

        ImageApi imageApi = new ImageApi(mockS3Client, rekognitionClient);
        string base64 = imageBase64;
        string bucketName = "bucketName";
        string key = "key";
        HttpStatusCode httpStatusCode = await imageApi.UploadImage(base64, bucketName, key);
        Assert.Equal(HttpStatusCode.OK, httpStatusCode);
    }

    //DetectLabels returns BadRequest when inappropriate image base64 is passed
    [Fact]
    public async Task DetectLabelsReturnsBadRequestWhenInappropriateBase64Passed()
    {
        IAmazonS3 s3Client = Substitute.For<IAmazonS3>();
        IAmazonRekognition rekognitionClient = Substitute.For<IAmazonRekognition>();

        //rekognitionClient.DetectLabels returns a list of labels
        rekognitionClient.DetectLabelsAsync(default, default)
            .ReturnsForAnyArgs(Task.FromResult(new DetectLabelsResponse { Labels = new List<Label>{
                new() { Confidence = 0.9f, Name = "label" }
            }}));

        ImageApi imageApi = new ImageApi(s3Client, rekognitionClient);
        string base64 = imageBase64;
        string bucketName = "bucketName";
        string key = "key";
        var labels = await imageApi.DetectLabels(imageApi.ConvertBase64ToMemoryStream(base64));
        Assert.True(labels.Count == 1);
    }

    //UploadImage returns BadRequest when inappropriate image base64 is passed
    [Fact]
    public async Task UploadImageReturnsBadRequestWhenInappropriateBase64Passed()
    {
        IAmazonS3 s3Client = Substitute.For<IAmazonS3>();
        IAmazonRekognition rekognitionClient = Substitute.For<IAmazonRekognition>();

        //s3Client.PutObjectAsync returns HttpStatusCode.OK
        s3Client.PutObjectAsync(default, default)
            .ReturnsForAnyArgs(Task.FromResult(new PutObjectResponse { HttpStatusCode = HttpStatusCode.OK }));

        //rekognitionClient.DetectLabels returns a list of labels
        rekognitionClient.DetectLabelsAsync(default, default)
            .ReturnsForAnyArgs(Task.FromResult(new DetectLabelsResponse { Labels = new List<Label>{
                new() { Confidence = 0.9f, Name = "label" },
             }}));

        ImageApi imageApi = new ImageApi(s3Client, rekognitionClient);
        string base64 = imageBase64;
        string bucketName = "bucketName";
        string key = "key";
        HttpStatusCode httpStatusCode = await imageApi.UploadImage(base64, bucketName, key);
        Assert.Equal(HttpStatusCode.BadRequest, httpStatusCode);
    } 
}

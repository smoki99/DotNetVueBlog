FROM microsoft/dotnet:2.1-sdk-alpine as builder

WORKDIR /usr/src/app

COPY . . 

# Setup Working directory
RUN apk add --no-cache nodejs nodejs-npm \
    && RUN dotnet restore \
    && npm install \
    && dotnet publish -o DotNetVueBlog -c Release

# Now start the Docker Container wanted only with the runtime
FROM microsoft/dotnet:2.1-runtime-alpine

RUN apk add --no-cache libuv \
    && ln -s /usr/lib/libuv.so.1 /usr/lib/libuv.so \

WORKDIR /usr/src/app

COPY --from=builder /usr/src/app/DotNetVueBlog .

EXPOSE 5000

CMD ["dotnet", "./DotNetVueBlog.dll"]


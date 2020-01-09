##### STAGE 1: Build #####
FROM node:10-alpine as builder
LABEL author="Kaplan"

# build-time variables 
# prod|staging its value will be come from outside 
#ARG env=production

WORKDIR /src
#ARG NPM_TOKEN
COPY package.json package-lock.json ./
COPY . .
RUN npm ci
RUN npm run build -- --prod --output-path=dist
#RUN npm run build-dev

##### STAGE 2: SetUp #####
FROM nginx:1.14.1-alpine
EXPOSE 4350
VOLUME /var/cache/nginx
COPY ./nginx/default.conf /etc/nginx/conf.d/default.conf
RUN rm -rf /usr/share/nginx/html/*
COPY --from=builder /src/dist /usr/share/nginx/html
CMD ["nginx", "-g", "daemon off;"]
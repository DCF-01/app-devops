pipeline {
    triggers {
        pollSCM('* * * * *')
    }
    agent {
        label 'ag-default'
    }
    environment {
        NEXUS_USERNAME = credentials('nexus-username')
        NEXUS_PASSWORD = credentials('nexus-password')
    }

    stages {
        stage('build-app1') {
            agent {
                label 'ag-default'
            }
            steps {
                sh 'docker compose build app1'
            }
        }

        stage('build-app2') {
            agent {
                label 'ag-default'
            }
            steps {
                sh 'docker compose build app2'
            }
        }

        stage('run-test') {
            agent {
                label 'ag-default'
            }
            steps {
                sh 'docker compose build tests'
            }
        }

        stage('docker-login') {
            agent {
                label 'ag-default'
            }
            steps {
                sh 'docker login localhost:8082 -u $NEXUS_USERNAME -p $NEXUS_PASSWORD'
                sh 'docker login localhost:8083 -u $NEXUS_USERNAME -p $NEXUS_PASSWORD'
                sh 'docker login localhost:8084 -u $NEXUS_USERNAME -p $NEXUS_PASSWORD'
            }
        }

        stage('push-to-nexus') {
            agent {
                label 'ag-default'
            }
            steps {
                sh 'docker compose push'
            }
        }

        stage('deploy') {
            agent {
                label 'ag_ubuntu'
            }
            options { skipDefaultCheckout() }
            steps {
                git branch: 'master',
                credentialsId: 'da0539b8-28de-4780-b7db-a34fe4bd6dc6',
                url: 'http://10.0.2.2:3000/gitea/example.git'

                sh 'sudo docker login 10.0.2.2:8082 -u $NEXUS_USERNAME -p $NEXUS_PASSWORD'
                sh 'sudo docker login 10.0.2.2:8083 -u $NEXUS_USERNAME -p $NEXUS_PASSWORD'
                sh 'docker pull 10.0.2.2:8082/repository/api'
                sh 'cat /etc/os-release'
            }
        }
    }
}
